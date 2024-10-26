using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezaVI.Light.Shared;

namespace VezaVI.Light.Components
{

    public enum DocumentBuilderElementListType { 
        Toolbar,
        Canvas
    }

    public class DocumentBuilderElementList : ComponentBase
    {

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            int seq = 0;
            builder.OpenElement(seq++, "ul");
            builder.AddAttribute(seq++, "ondragover", "event.preventDefault();");
            builder.AddAttribute(seq++, "ondragstart", "event.dataTransfer.setData('', event.target.id);");
            builder.AddAttribute(++seq, "ondragenter", EventCallback.Factory.Create<ElementDragEventArgs>(this, HandleDragEnter));
            builder.AddAttribute(++seq, "ondragleave", EventCallback.Factory.Create<ElementDragEventArgs>(this, HandleDragLeave));
            builder.AddAttribute(++seq, "ondrop", EventCallback.Factory.Create<DragEventArgs>(this, () => HandleDrop(null)));

            foreach (var element in Container.GetElements(AllowedType))
            {
                builder.OpenElement(seq++, "li");
                builder.AddAttribute(++seq, "draggable", $"true");
                builder.AddAttribute(++seq, "ondragstart", EventCallback.Factory.Create<ElementDragEventArgs>(this, () => HandleDragStart(element)));
                if (AllowedType == DocumentBuilderElementListType.Canvas)
                    builder.AddAttribute(++seq, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, () => HandleOnClick(element)));
                
                builder.OpenComponent(++seq, element.RenderType);
                builder.AddAttribute(++seq, "Element", element);
                builder.CloseComponent();

                builder.CloseElement();
            }
            if (AllowedType == DocumentBuilderElementListType.Toolbar)
            {
                builder.OpenElement(seq++, "li");
                builder.AddAttribute(++seq, "draggable", $"false");
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(seq++, "class", "oi oi-trash");
                builder.CloseElement();
                builder.AddContent(++seq, "Drag an Element here to remove it");
                builder.CloseElement();
            }
            if (Container.GetElements(AllowedType).Count() == 0) {
                builder.OpenElement(seq++, "span");
                builder.AddAttribute(++seq, "draggable", $"false");
                builder.AddAttribute(++seq, "class", $"vi-document-builder-no-elements");
                builder.AddContent(++seq, "Drag an Element here to start building");
                builder.CloseElement();
            }
            builder.CloseElement();
        }

        protected async override Task OnInitializedAsync()
        {
            Container.OnIndexReset += Container_OnIndexReset;
        }

        private void Container_OnIndexReset(object sender, EventArgs e)
        {
            currentIndex = -1;
        }

        [Parameter]
        public DocumentBuilderElementListType AllowedType { get; set; }
        [CascadingParameter] 
        public DocumentBuilderCanvas Container { get; set; }

        string dropClass = "";

        private void HandleDragEnter()
        {
            dropClass = "can-drop";
        }

        private void HandleDragLeave()
        {
            dropClass = "";
        }

        int GetIndex(IDragableElement item)
        {
            if (item == null)
                return -1;
            return Container.GetElements(AllowedType).ToList().FindIndex(a => a.ElementID == item.ElementID);
        }
        
        int currentIndex = -1;
        private async Task HandleDrop(IDragableElement targetElement)
        {
            if (AllowedType == DocumentBuilderElementListType.Canvas)
            {
                int targetIndex = GetIndex(targetElement);
                if (currentIndex >= 0)
                {
                    /*Existing*/
                    var current = Container.GetElements(AllowedType)[currentIndex];
                    Container.GetElements(AllowedType).RemoveAt(currentIndex);
                    if (targetIndex == -1)
                        Container.GetElements(AllowedType).Add(current);
                    else
                        Container.GetElements(AllowedType).Insert(targetIndex, current);
                    currentIndex = -1;
                    await Container.ChangeState();
                }
                else
                {
                    /*New Item*/
                    IDragableElement elem = Container.Payload.CreateNew(AllowedType);
                    if (await Container.UpdateElement(elem, ElementAction.Add))
                    {
                        if (targetIndex >= 0)
                            Container.GetElements(AllowedType).Insert(targetIndex, elem);
                        else
                            Container.GetElements(AllowedType).Add(elem);
                        await Container.ChangeState();
                    }
                }
            }
            else
            {
                if (Container.Payload.State == DocumentBuilderElementListType.Canvas)
                {
                    /*Delete Element*/
                    if (await Container.UpdateElement(Container.Payload, ElementAction.Delete))
                    {
                        Container.GetElements(DocumentBuilderElementListType.Canvas).Remove(Container.Payload);
                        Container.Payload = null;
                        await Container.ChangeState();
                    }
                }
            }
            ReOrder();
            Container.ResetIndex();
        }

        private void ReOrder()
        {
            int counter = 1;
            foreach (var prop in Container.GetElements(AllowedType))
            {
                prop.Sort = counter;
                counter++;
            }
        }

        private void HandleDragStart(IDragableElement element)
        {
            currentIndex = GetIndex(element);
            Container.Payload = element;
        }

        private void HandleOnClick(IDragableElement element)
        {
            Container.SetSelectedElement(element);
        }
    }
}

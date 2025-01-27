// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SST.Client.Shared
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http

#nullable disable
    ;
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http.Json

#nullable disable
    ;
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization

#nullable disable
    ;
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms

#nullable disable
    ;
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing

#nullable disable
    ;
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web

#nullable disable
    ;
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http

#nullable disable
    ;
#nullable restore
#line 8 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.JSInterop

#nullable disable
    ;
#nullable restore
#line 9 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Client

#nullable disable
    ;
#nullable restore
#line 10 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Client.Shared

#nullable disable
    ;
#nullable restore
#line 11 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SST.Shared

#nullable disable
    ;
#nullable restore
#line 12 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization

#nullable disable
    ;
#nullable restore
#line 13 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Text.Json

#nullable disable
    ;
#nullable restore
#line 14 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.LocalStorage

#nullable disable
    ;
#nullable restore
#line 15 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Net.Http.Headers

#nullable disable
    ;
#nullable restore
#line 16 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity

#nullable disable
    ;
#nullable restore
#line 17 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using VezaVI.Light.Components

#nullable disable
    ;
#nullable restore
#line 18 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using VezaVI.Light.Shared

#nullable disable
    ;
#nullable restore
#line 19 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.Modal

#nullable disable
    ;
#nullable restore
#line 20 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using Blazored.Modal.Services

#nullable disable
    ;
#nullable restore
#line 21 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.Security.Claims

#nullable disable
    ;
#nullable restore
#line 22 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using System.IO

#nullable disable
    ;
#nullable restore
#line 23 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SixLabors.ImageSharp

#nullable disable
    ;
#nullable restore
#line 24 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\_Imports.razor"
using SixLabors.ImageSharp.Processing

#line default
#line hidden
#nullable disable
    ;
    #nullable restore
    public partial class QuestionDecisionTree : global::Microsoft.AspNetCore.Components.ComponentBase, IDisposable
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 19 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionDecisionTree.razor"
       
    [Parameter]
    public  bool ViewToggle { get; set; }
    [Parameter]
    public bool SimulationToggle { get; set; }
    [Parameter]
    public bool ShowToggle { get; set; }

    private List<VezaPathNode> Nodes = new List<VezaPathNode>();
    private Guid SelectedContractQuestionID { get; set; }
    private QuestionNodeTreeBuilder _treeBuilder;
    [CascadingParameter]
    public QuestionNodeTreeBuilder TreeBuilder {
        get
        {
            return _treeBuilder;
        }
        set
        {
            _treeBuilder = value;
            if (_treeBuilder != null)
                _treeBuilder.TreeChanged += TreeChanged;
        }
    }

    public string TreeCSS()
    {
        return ViewToggle ? "vi-flow-decision-tree" : "vi-flow-dendrogram";
    }

    private async void TreeChanged(object sender, EventArgs e)
    {
        GenerateTree();
        await InvokeAsync(() => StateHasChanged());
    }

    public void Dispose()
    {
        if (_treeBuilder != null)
            _treeBuilder.TreeChanged -= TreeChanged;
    }

    private void GenerateTree()
    {
        Nodes = new List<VezaPathNode>();
        var questions = TreeBuilder.GetAllQuestions();
        var root = questions.FirstOrDefault(x => x.IsRoot);
        if (root != null)
        {
            VezaPathNode node = new VezaPathNode(root.QuestionText, root.ID, null);
            node.NType = NodeType.Normal;
            node.IsSelected = (node.EntityID == SelectedContractQuestionID);
            Nodes.Add(node);
            GetNodes(node, root, questions);
        }
    }

    private bool FindInParent(VezaPathNode node, ContractQuestion nextQuestion)
    {
        if (node == null)
            return false;
        if (node.EntityID == nextQuestion.ID)
            return true;
        return FindInParent(node.ParentNode, nextQuestion);
    }

    private void GetNodes(VezaPathNode parent, ContractQuestion question, List<ContractQuestion> questions)
    {
        VezaPathNode node;
        if (question.IsRoot)
        {
            node = parent;
        }
        else
        {
            node = new VezaPathNode(question.QuestionText, question.ID, null);
            node.IsSelected = (node.EntityID == SelectedContractQuestionID);
            node.NType = NodeType.Normal;
            parent.AddNodes(node);
        }
        if ((question.TypeOfQuestion == (int)QuestionType.Quantity) || (question.TypeOfQuestion == (int)QuestionType.UserFieldsOnly))
        {
            var nextQuestion = questions.FirstOrDefault(x => x.ID == question.NextQuestionID);
            if (nextQuestion != null)
            {
                /*Check Parents for same Question*/
                if (FindInParent(node, nextQuestion))
                {
                    VezaPathNode infNode = new VezaPathNode($"Infinite Question Sequence Detected. Question '{nextQuestion.QuestionText}' already in tree.", Guid.Empty, null);
                    infNode.NType = NodeType.Error;
                    node.AddNodes(infNode);
                }
                else
                {
                    GetNodes(node, nextQuestion, questions);
                }
            }
        }
        else
        {
            foreach (var answer in TreeBuilder.GetAnswers(question.ID))
            {
                VezaPathNode answerNode = new VezaPathNode(answer.AnswerText, question.ID, null);
                answerNode.NType = NodeType.Answer;
                node.AddNodes(answerNode);
                var nextQuestion = questions.FirstOrDefault(x => x.ID == answer.NextQuestionID);
                if (nextQuestion != null)
                {
                    /*Check Parents for same Question*/
                    if (FindInParent(answerNode, nextQuestion))
                    {
                        VezaPathNode infNode = new VezaPathNode($"Question '{nextQuestion.QuestionText}' is already in this tree.", Guid.Empty, null);
                        infNode.NType = NodeType.Error;
                        answerNode.AddNodes(infNode);
                    }
                    else
                    {
                        GetNodes(answerNode, nextQuestion, questions);
                    }
                }
            }
        }
    }

    private void NodeClicked(VezaPathNodeClickEvent e)
    {
        if (SelectedContractQuestionID == e.Node.EntityID)
            SelectedContractQuestionID = Guid.Empty;
        else
            SelectedContractQuestionID = e.Node.EntityID;
        TreeBuilder.RefreshDecisionTree(SelectedContractQuestionID);
    }


#line default
#line hidden
#nullable disable

    }
}
#pragma warning restore 1591

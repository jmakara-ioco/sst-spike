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
    public partial class QuestionNodeTreeBuilder : global::Microsoft.AspNetCore.Components.ComponentBase
    #nullable disable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
       

    public void Validate()
    {
        validations.Clear();
        foreach (ContractQuestion q in Questions)
        {
            q.Status = "";
            if (string.IsNullOrEmpty(q.QuestionText))
            {
                q.Status = "No Question Text Entered";
            }
            if (string.IsNullOrEmpty(q.Information))
            {
                if (q.Status != string.Empty)
                    q.Status += ";";
                q.Status = "No Question Information Entered";
            }
        }
        foreach (var ans in QuestionAnswers)
        {
            ans.Status = "";
            if (string.IsNullOrEmpty(ans.AnswerText))
            {
                ans.Status = "No Answer Text Entered";
            }
        }
        StateHasChanged();
    }

    private List<ContractQuestion> VisibleQuestions()
    {
        if (SelectedElement != Guid.Empty)
        {
            return Questions.Where(x => x.ID == SelectedElement).ToList();
        }
        return Questions;
    }

    private bool _viewToggle = true;
    private bool _simToggle = true;
    private bool _showToggle = true;

    private void ToggleView()
    {
        _viewToggle = !_viewToggle;
        //StateHasChanged();
    }

    private void ToggleSim()
    {
        _simToggle = !_simToggle;
        //StateHasChanged();
    }

    private void ToggleShow()
    {
        _showToggle = !_showToggle;
        //StateHasChanged();
    }

    [Parameter]
    public Guid ContractTransactionID { get; set; }
    private List<ContractQuestion> Questions = new List<ContractQuestion>();
    private List<ContractQuestionAnswer> QuestionAnswers { get; set; } = new List<ContractQuestionAnswer>();
    private List<ContractTransactionDataField> DataFields { get; set; } = new List<ContractTransactionDataField>();
    private List<ContractTransactionTemplate> Templates { get; set; } = new List<ContractTransactionTemplate>();
    private List<ContractTransactionEntity> Entities { get; set; } = new List<ContractTransactionEntity>();
    private List<ContractClause> Clauses { get; set; } = new List<ContractClause>();

    List<string> validations = new List<string>();

    protected async override Task OnInitializedAsync()
    {
        /*Data Fields*/
        var dataFields = await ContractDataFieldService.GetAllAsync("FieldName", new List<VezaVIGridFilter>()
{
            new VezaVIGridFilter() { Field = "ContractTransactionID", Value = ContractTransactionID.ToString(), Equals = true }
        });
        DataFields = dataFields.Items;

        /**/
        var templates = await ContractTransactionTemplateService.GetAllAsync("Name", new List<VezaVIGridFilter>()
    {
            new VezaVIGridFilter() { Field = "ContractTransactionID", Value = ContractTransactionID.ToString(), Equals = true }
        });
        Templates = templates.Items;


        var clauses = await ContractClauseService.GetAllAsync("Code", new List<VezaVIGridFilter>()
    {
            new VezaVIGridFilter() { Field = "ContractTransactionID", Value = ContractTransactionID.ToString(), Equals = true }
        });
        Clauses = clauses.Items;

        var entities = await ContractTransactionEntityService.GetAllAsync("Name", new List<VezaVIGridFilter>()
    {
            new VezaVIGridFilter() { Field = "ContractTransactionID", Value = ContractTransactionID.ToString(), Equals = true }
        });
        Entities = entities.Items;

        var questions = await ContractQuestionService.GetAllAsync("QuestionText", new List<VezaVIGridFilter>() {
            new VezaVIGridFilter() { Field = "ContractTransactionID", Value = ContractTransactionID.ToString(), Equals = true }
        });
        Questions = questions.Items.ToList();
        //Questions = questions.Items.Where(x => x.ID == SelectedElement).ToList();

        TreeChanged?.Invoke(this, EventArgs.Empty);
        StateHasChanged();
    }

    public async void RemoveQuestion(ContractQuestion question)
    {
        var result = await ContractQuestionService.DeleteAsync(question.ID);
        if (result.Successful)
        {
            Questions.Remove(question);
            TreeChanged?.Invoke(this, EventArgs.Empty);
            await InvokeAsync(() => StateHasChanged());
        }
        else
        {
            question.Status = result.Errors.FirstOrDefault();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public async void SaveQuestion(ContractQuestion question)
    {
        var result = await ContractQuestionService.UpdateAsync(question);
        if (result.Successful)
        {
            question.Status = "Changes Successfully Saved";
            TreeChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            question.Status = result.Errors.FirstOrDefault();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public async void AddQuestion()
    {
        ContractQuestion question = new ContractQuestion()
        {
            Status = string.Empty,
            QuestionText = string.Empty,
            TypeOfQuestion = 0,
            ContractTransactionID = this.ContractTransactionID,
            IsRoot = (Questions.Count == 0)
        };
        var result = await ContractQuestionService.AddAsync(question);
        if (result.Successful)
        {
            question.Status = "Question Successfully Added";
            Questions.Add(question);
            TreeChanged?.Invoke(this, EventArgs.Empty);
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public async void MarkAsRoot(ContractQuestion question)
    {
        foreach (var quest in Questions)
        {
            quest.IsRoot = (quest.ID == question.ID);
        }
        TreeChanged?.Invoke(this, EventArgs.Empty);
        await InvokeAsync(() => StateHasChanged());
    }

    public List<ContractTransactionDataField> GetAllDataFields()
    {
        return DataFields;
    }

    public List<ContractClause> GetAllContractClauses()
    {
        return Clauses;
    }

    public List<ContractQuestion> GetAllQuestions()
    {
        return Questions;
    }

    public List<ContractTransactionTemplate> GetAllTemplates()
    {
        return Templates;
    }

    public List<ContractTransactionEntity> GetAllEntities()
    {
        return Entities;
    }

    public event TreeChangedEventHandler TreeChanged;
    public delegate void TreeChangedEventHandler(object sender, EventArgs e);

    public async Task InitAnswers(List<ContractQuestionAnswer> answers)
    {
        foreach (var answer in answers)
        {
            var node = QuestionAnswers.FirstOrDefault(x => x.ID == answer.ID);
            if (node != null)
            {
                node.NextQuestionID = answer.NextQuestionID;
                node.QuestionID = answer.QuestionID;
                node.AnswerText = answer.AnswerText;
            }
            else
            {
                QuestionAnswers.Add(answer);
            }
        }
        TreeChanged?.Invoke(this, EventArgs.Empty);
    }

    public async Task AddAnswer(ContractQuestionAnswer answer)
    {
        var result = await ContractQuestionAnswerService.AddAsync(answer);
        if (result.Successful)
        {
            answer.Status = "Changes Successfully Saved";
            if (QuestionAnswers.FirstOrDefault(x => x.ID == answer.ID) == null)
            {
                QuestionAnswers.Add(answer);
            }
            TreeChanged?.Invoke(this, EventArgs.Empty);
            await InvokeAsync(() => StateHasChanged());
        }
        else
        {
            answer.Status = result.Errors.FirstOrDefault();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public async Task SaveAnswer(ContractQuestionAnswer answer)
    {
        var result = await ContractQuestionAnswerService.UpdateAsync(answer);
        if (result.Successful)
        {
            answer.Status = "Changes Successfully Saved";
            if (QuestionAnswers.FirstOrDefault(x => x.ID == answer.ID) == null)
            {
                QuestionAnswers.Add(answer);
            }
            TreeChanged?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            answer.Status = result.Errors.FirstOrDefault();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public async void TryRemoveAnswer(ContractQuestionAnswer answer)
    {
        /*Delete*/
        var result = await ContractQuestionAnswerService.DeleteAsync(answer.GetID());
        if (result.Successful)
        {
            QuestionAnswers.Remove(answer);
            TreeChanged?.Invoke(this, EventArgs.Empty);
            await InvokeAsync(() => StateHasChanged());
        }
        else
        {
            answer.Status = result.Errors.FirstOrDefault();
            await InvokeAsync(() => StateHasChanged());
        }
    }

    public List<ContractQuestionAnswer> GetAnswers(Guid questionID)
    {
        return QuestionAnswers.Where(x => x.QuestionID == questionID).ToList();
    }

    private Guid SelectedElement { get; set; } = Guid.Empty;
    public void RefreshDecisionTree(Guid id)
    {
        SelectedElement = id;
        TreeChanged?.Invoke(this, EventArgs.Empty);
        StateHasChanged();
    }

#line default
#line hidden
#nullable disable

        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        AuthenticationStateProvider

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 7 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                    AuthenticationStateProvider

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractTransactionEntity>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 6 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                                    ContractTransactionEntityService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractTransactionTemplate>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 5 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                                      ContractTransactionTemplateService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractTransactionDataField>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 4 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                                       ContractDataFieldService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractQuestionAnswer>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 3 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                                 ContractQuestionAnswerService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractClause>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 2 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                         ContractClauseService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private 
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
        IVezaDataService<ContractQuestion>

#line default
#line hidden
#nullable disable
         
#nullable restore
#line 1 "D:\Code\CloudberrySoftwareSolutions\SST-Law\ContractBuilder-main\SST\SST\Client\Shared\QuestionNodeTreeBuilder.razor"
                                           ContractQuestionService

#line default
#line hidden
#nullable disable
         { get; set; }
         = default!;
    }
}
#pragma warning restore 1591
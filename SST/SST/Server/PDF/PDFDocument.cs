using SST.Server.Data;
using SST.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace SST.Server
{
    public class PDFDocument
    {
        public static PDFToken GenerateTemplate(ApplicationDbContext context, Guid templateID)
        {
            PDFToken token = new PDFToken();
            var template = context.ContractTransactionTemplates.FirstOrDefault(x => x.ID == templateID);
            var templateElement = context.ContractTemplateElements.FirstOrDefault(x => x.ContractTransactionTemplateID == template.ID);
            var dataFields = context.ContractTransactionDataFields.Where(x => x.ContractTransactionID == template.ContractTransactionID);
            var clauses = context.ContractClauses.ToList();
            var contractTransaction = context.ContractTransactions.FirstOrDefault(x => x.ID == template.ContractTransactionID);
            var firm = context.Firms.FirstOrDefault(x => x.ID == contractTransaction.FirmID);
            var stylesheet = context.FirmStylings.FirstOrDefault(x => x.FirmID == contractTransaction.FirmID);

            //[UDF:830f3d29-fb47-407b-a23a-7aae7b7d2cd4]
            string html = GenerateTemplateStr(new ContractTemplateElement[] { templateElement }, stylesheet);
            foreach (var clause in clauses)
            {
                html = html.Replace($"[CLAUSE:{clause.ID}]", clause.ClauseText);
            }
            foreach (var dataField in dataFields)
            {
                html = html.Replace($"[UDF:{dataField.ID.ToString().ToLower()}]", dataField.FieldName);
            }
            token.Content = html;
            token.HeadersAndFooters.Add(1, GetHeaderText(stylesheet.HeaderLeft, firm));
            token.HeadersAndFooters.Add(2, GetHeaderText(stylesheet.HeaderCenter, firm));
            token.HeadersAndFooters.Add(3, GetHeaderText(stylesheet.HeaderRight, firm));
            token.HeadersAndFooters.Add(4, GetHeaderText(stylesheet.FooterLeft, firm));
            token.HeadersAndFooters.Add(5, GetHeaderText(stylesheet.FooterCenter, firm));
            token.HeadersAndFooters.Add(6, GetHeaderText(stylesheet.FooterRight, firm));
            token.HeadersAndFooters.Add(7, stylesheet.Font);
            token.HeadersAndFooters.Add(8, stylesheet.ShowHeaderLine.ToString());
            token.HeadersAndFooters.Add(9, stylesheet.ShowFooterLine.ToString());
            token.HeadersAndFooters.Add(10, stylesheet.HeaderHeight.ToString());
            token.HeadersAndFooters.Add(11, stylesheet.FooterHeight.ToString());            
            return token;
        }

        public static PDFToken GenerateTransaction(ApplicationDbContext context, Guid historyID)
        {
            PDFToken token = new PDFToken();
            var history = context.ContractHistories.FirstOrDefault(x => x.ID == historyID);
            if (history != null)            {
                Guid contractTransactionID = Guid.Empty;
                var clauses = context.ContractClauses.ToList();
                var sim = JsonSerializer.Deserialize<QuestionSimulation>(history.ContractData);
                List<Guid> templates = new List<Guid>();
                List<Guid> ignoredClauses = new List<Guid>();
                foreach (var q in sim.Questions)
                {
                    var question = context.ContractQuestions.Include(x => x.Templates).Include(x => x.IgnoredContractClauses).FirstOrDefault(x => x.ID == q.QuestionID);
                    contractTransactionID = question.ContractTransactionID;

                    foreach (var ignoredClause in question.IgnoredContractClauses)
                    {
                        if (!ignoredClauses.Contains(ignoredClause.ContractClauseID))
                            ignoredClauses.Add(ignoredClause.ContractClauseID);
                    }
                    foreach (var template in question.Templates.OrderBy(x => x.SequenceNumber))
                    {
                        if (!templates.Contains(template.ContractTransactionTemplateID))
                            templates.Add(template.ContractTransactionTemplateID);
                    }
                    if ((q.AnswerID != null) && (q.AnswerID != Guid.Empty))
                    {
                        var answer = context.ContractQuestionAnswers.Include(x => x.IgnoredContractClauses).FirstOrDefault(x => x.ID == q.AnswerID);
                        if (answer != null)
                        {
                            foreach (var ignoredClause in answer.IgnoredContractClauses)
                            {
                                if (!ignoredClauses.Contains(ignoredClause.ContractClauseID))
                                    ignoredClauses.Add(ignoredClause.ContractClauseID);
                            }
                            if ((answer.ContractTemplateID != null) && (!templates.Contains((Guid)answer.ContractTemplateID)))
                            {
                                templates.Add((Guid)answer.ContractTemplateID);
                            }
                        }
                    }
                }
                var dataFields = context.ContractTransactionDataFields.Where(x => x.ContractTransactionID == contractTransactionID);
                var contractTransaction = context.ContractTransactions.FirstOrDefault(x => x.ID == contractTransactionID);
                var stylesheet = context.FirmStylings.FirstOrDefault(x => x.FirmID == contractTransaction.FirmID);
                var firm = context.Firms.FirstOrDefault(x => x.ID == contractTransaction.FirmID);
                var templateElements = context.ContractTemplateElements.Where(x => templates.Contains(x.ContractTransactionTemplateID));
                List<ContractTemplateElement> elements = new List<ContractTemplateElement>();
                foreach(var templateID in templates)
                {
                    var elementsToAdd = templateElements.Where(x => x.ContractTransactionTemplateID == templateID);
                    elements.AddRange(elementsToAdd);
                }
                var entityClause = context.ContractTransactionEntityClauses.Include(x => x.ContractTransactionEntity).Where(x => x.ContractTransactionEntity.ContractTransactionID == contractTransactionID);

                string html = GenerateTemplateStr(elements.ToArray(), stylesheet);
                
                html = html.Replace($"[INDEX]", "<div id=\"index\"></div>");
                foreach (var clause in clauses)
                {
                    html = html.Replace($"[CLAUSE:{clause.ID}]", (ignoredClauses.Contains(clause.ID)) ? "" : clause.ClauseText);
                }
                foreach (var dataField in dataFields)
                {
                    html = html.Replace($"[UDF:{dataField.ID.ToString().ToLower()}]", sim[dataField.ID]);
                }
                foreach (var clause in entityClause)
                {
                    var fullClauseText = string.Empty;
                    //Generate
                    var entity = sim.Entities.FirstOrDefault(x => x.EntityID == clause.ContractTransactionEntityID);
                    if (entity != null)
                    {
                        for (int i = 1; i <= entity.NrOfEntities; i++) {
                            var clauseText = clause.ClauseText;
                            foreach (var entityField in entity.DataFields)
                            {
                                clauseText = clauseText.Replace($"[ENTITYUDF:{entityField.DataFieldID.ToString().ToLower()}]", entityField[i]);
                            }
                            fullClauseText += clauseText;
                        }
                    }
                    //Replace
                    html = html.Replace($"[ENTITYCLAUSE:{clause.ID}]", fullClauseText);
                }


                token.Content = html;
                token.HeadersAndFooters.Add(1, GetHeaderText(stylesheet.HeaderLeft, firm));
                token.HeadersAndFooters.Add(2, GetHeaderText(stylesheet.HeaderCenter, firm));
                token.HeadersAndFooters.Add(3, GetHeaderText(stylesheet.HeaderRight, firm));
                token.HeadersAndFooters.Add(4, GetHeaderText(stylesheet.FooterLeft, firm));
                token.HeadersAndFooters.Add(5, GetHeaderText(stylesheet.FooterCenter, firm));
                token.HeadersAndFooters.Add(6, GetHeaderText(stylesheet.FooterRight, firm));
                token.HeadersAndFooters.Add(7, stylesheet.Font);
                token.HeadersAndFooters.Add(8, stylesheet.ShowHeaderLine.ToString());
                token.HeadersAndFooters.Add(9, stylesheet.ShowFooterLine.ToString());
                token.HeadersAndFooters.Add(10, stylesheet.HeaderHeight.ToString());
                token.HeadersAndFooters.Add(11, stylesheet.FooterHeight.ToString());
                token.HeadersAndFooters.Add(12, stylesheet.ID.ToString());

            }
            return token;
        }

        public static string GetHeaderText(int option, Firm firm)
        {
            switch (option)
            {
                case 1:
                    return "Page [page] of [toPage]";
                case 2:
                    return DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
                case 3:
                    return firm.FirmName;
                default:
                    return "";
            }
        }

        public static string GenerateTemplateStr(ContractTemplateElement[] templateElements, FirmStyling stylesheet)
        {
            string html = string.Empty;
            html += "<html><head>";
            html += stylesheet.GenerateStyleSheet();
            html += "</head>";
            html += "<body>";
            int counter = 0;
            foreach (var element in templateElements)
            {
                if (element != null)
                {
                    if (counter > 0)
                        html += "<div id=\"VezaRichTextBox\" style=\"page-break-before: always; break-before: always;\">";
                    else
                        html += "<div id=\"VezaRichTextBox\">";
                    html += element.TemplateText;
                    html += "</div>";
                    counter++;
                }
            }
            html += stylesheet.GenerateScripts();
            html += "</body></html>";
            return html;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SST.Shared
{
    public class DocumentParser
    {
        public static string ParseToDisplay(string document, 
            List<ContractTransactionDataField> userFields,
            List<ContractClause> userClauses,
            List<ContractTransactionEntityDataField> userEntityFields,
            List<EditorEntityClause> userEntityClauses)
        {
            document = document.Replace($"[INDEX]", $"<span id=\"index\" class=\"vi-editor-entity-clause\" contenteditable=\"false\">Document Index</span>");
            foreach (var udf in userFields)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"[UDF:{udf.ID}]", $"<span id=\"{udf.ID.ToString().ToLower()}\" class=\"vi-editor-udf\" contenteditable=\"false\">{udf.FieldName}</span>");
            }
            foreach (var clause in userClauses)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"[CLAUSE:{clause.ID}]", $"<span id=\"{clause.ID.ToString().ToLower()}\" class=\"vi-editor-clause\" contenteditable=\"false\">Document Clause: {clause.Code}</span>");
            }
            foreach (var udf in userEntityFields)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"[ENTITYUDF:{udf.ID}]", $"<span id=\"{udf.ID.ToString().ToLower()}\" class=\"vi-editor-entity-udf\" contenteditable=\"false\">{udf.FieldName}</span>");
            }
            foreach (var clause in userEntityClauses)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"[ENTITYCLAUSE:{clause.ContractTransactionEntityClauseID}]", $"<span id=\"{clause.ContractTransactionEntityClauseID.ToString().ToLower()}\" class=\"vi-editor-entity-clause\" contenteditable=\"false\">Grouped Field Clause: {clause.ContractTransactionEntityName} - {clause.ClauseName}</span>");
            }
            return document;
        }

        public static string ParseToSave(string document,
            List<ContractTransactionDataField> userFields,
            List<ContractClause> userClauses,
            List<ContractTransactionEntityDataField> userEntityFields,
            List<EditorEntityClause> userEntityClauses)
        {
            document = document.Replace($"<span id=\"index\" class=\"vi-editor-entity-clause\" contenteditable=\"false\">Document Index</span>", $"[INDEX]");
            foreach (var udf in userFields)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"<span id=\"{udf.ID.ToString().ToLower()}\" class=\"vi-editor-udf\" contenteditable=\"false\">{udf.FieldName}</span>", $"[UDF:{udf.ID}]");
            }
            foreach (var clause in userClauses)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"<span id=\"{clause.ID.ToString().ToLower()}\" class=\"vi-editor-clause\" contenteditable=\"false\">Document Clause: {clause.Code}</span>", $"[CLAUSE:{clause.ID}]");
            }
            foreach (var udf in userEntityFields)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"<span id=\"{udf.ID.ToString().ToLower()}\" class=\"vi-editor-entity-udf\" contenteditable=\"false\">{udf.FieldName}</span>", $"[ENTITYUDF:{udf.ID}]");
            }
            foreach (var clause in userEntityClauses)
            {
                //var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
                document = document.Replace($"<span id=\"{clause.ContractTransactionEntityClauseID.ToString().ToLower()}\" class=\"vi-editor-entity-clause\" contenteditable=\"false\">Grouped Field Clause: {clause.ContractTransactionEntityName} - {clause.ClauseName}</span>", $"[ENTITYCLAUSE:{clause.ContractTransactionEntityClauseID}]");
            }
            return document;
        }

    }
}

var oDoc;

function initDoc() {
    oDoc = document.getElementById("VezaRichTextBox");
}

function setDocText(text) {
    oDoc = document.getElementById("VezaRichTextBox");
    oDoc.innerHTML = text;
}

function formatDoc(sCmd, sValue) {
    document.execCommand(sCmd, false, sValue);
    oDoc.focus();
}

function addUDF(udfName, udfID) {
    oDoc.focus();
    var html = '<span id="' + udfID + '" class="vi-editor-udf" contenteditable=false>' + udfName + '</span>';
    pasteHtmlAtCaret(html);
}

function addEntityUDF(udfName, udfID) {
    oDoc.focus();
    var html = '<span id="' + udfID + '" class="vi-editor-entity-udf" contenteditable=false>' + udfName + '</span>';
    pasteHtmlAtCaret(html);
}

function addClause(clauseName, clauseID) {
    oDoc.focus();
    var html = '<span id="' + clauseID + '" class="vi-editor-clause" contenteditable="false">Document Clause: ' + clauseName + '</span>';
    pasteHtmlAtCaret(html);
}

function addEntityClause(clauseName, clauseID) {
    oDoc.focus();
    var html = '<span id="' + clauseID + '" class="vi-editor-entity-clause" contenteditable="false">Grouped Field Clause: ' + clauseName + '</span>';
    pasteHtmlAtCaret(html);
}

function addIndex() {
    oDoc.focus();
    var html = '<span id="index" class="vi-editor-entity-clause" contenteditable="false">Document Index</span>';
    pasteHtmlAtCaret(html);
}

function pasteHtmlAtCaret(html) {
    var sel, range;
    if (window.getSelection) {
        // IE9 and non-IE
        sel = window.getSelection();
        if (sel.getRangeAt && sel.rangeCount) {
            range = sel.getRangeAt(0);
            range.deleteContents();

            // Range.createContextualFragment() would be useful here but is
            // only relatively recently standardized and is not supported in
            // some browsers (IE9, for one)
            var el = document.createElement("div");
            el.innerHTML = html;
            var frag = document.createDocumentFragment(), node, lastNode;
            while ((node = el.firstChild)) {
                lastNode = frag.appendChild(node);
            }
            var firstNode = frag.firstChild;
            range.insertNode(frag);

            // Preserve the selection
            if (lastNode) {
                range = range.cloneRange();
                range.setStartAfter(lastNode);
                range.collapse(true);
                sel.removeAllRanges();
                sel.addRange(range);
            }
        }
    } else if ((sel = document.selection) && sel.type != "Control") {
        // IE < 9
        var originalRange = sel.createRange();
        originalRange.collapse(true);
        sel.createRange().pasteHTML(html);
        var range = sel.createRange();
        range.setEndPoint("StartToStart", originalRange);
        range.select();
    }

}
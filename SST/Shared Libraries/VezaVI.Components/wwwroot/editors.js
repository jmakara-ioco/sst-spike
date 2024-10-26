(function () {
    var showClass = "vi-float-label";
    alert('test 2');
    $("input").bind("checkval", function () {
        alert('test');
        var label = $(this).prev("div");
        if (this.value !== "") {
            label.addClass(showClass);
        } else {
            label.removeClass(showClass);
        }
    }).on("keyup", function () {
        $(this).trigger("checkval");
    }).on("focus", function () {
        $(this).trigger("checkval");
    }).on("blur", function () {
        $(this).trigger("checkval");
    });
});
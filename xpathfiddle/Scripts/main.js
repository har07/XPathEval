function getModel() {
    var model = {
        Id: "",
        Revision: 0,
        Xml: ace.edit("xmleditor").getSession().getValue(),
        Xpath: ace.edit("xpatheditor").getSession().getValue(),
        XpathResult: {
            Result: ""
        }
    };
    return JSON.stringify(model);
}

function executeXpath() {
    $.ajax({
        type: "POST",
        url: '/XPath/ExecuteXpath',
        contentType: 'application/json',
        data: getModel(),
        success: function (result) {
            if (result["error"] != "") {
                //$('#status').val(result["error"]);
                alert(result["error"]);
            } else {
                xpathresult = result["data"];
                ace.edit("outputdisplay").getSession().setValue(result["data"]);
            }
        },
        error: function (xhr) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

$(document).ready(function () {
    var xmleditor = ace.edit("xmleditor");
    xmleditor.setTheme("ace/theme/sqlserver");
    xmleditor.getSession().setMode("ace/mode/xml");

    var xpatheditor = ace.edit("xpatheditor");
    xpatheditor.setTheme("ace/theme/sqlserver");
    xpatheditor.getSession().setMode("ace/mode/xquery");

    var outputdisplay = ace.edit("outputdisplay");
    outputdisplay.setTheme("ace/theme/sqlserver");
    outputdisplay.getSession().setMode("ace/mode/xml");
});
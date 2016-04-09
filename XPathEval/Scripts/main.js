/* global variables */
var __engineids__ = ['xpath3', 'xpath1', 'xquery3'];
var __engines__ = {
    'xpath3': 'XPath 3.0',
    'xpath1': 'XPath 1.0',
    'xquery3': 'XQuery 3.0',
};

function getModel() {
    var model = {
        Id: "",
        Revision: 0,
        Engine: $('#engine-id').val(),
        Xml: ace.edit("xmleditor").getSession().getValue(),
        XPath: ace.edit("xpatheditor").getSession().getValue(),
        Result: {
            Data: ace.edit("outputdisplay").getSession().getValue()
        }
    };
    return JSON.stringify(model);
}

function executeXPath() {
    $.ajax({
        type: "POST",
        url: '/XPath/ExecuteXPath',
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

function formatXml() {
    $.ajax({
        type: "POST",
        url: '/XPath/FormatXml',
        contentType: 'application/json',
        data: getModel(),
        success: function (result) {
            if (result["error"] != "") {
                //$('#status').val(result["error"]);
                alert(result["error"]);
            } else {
                ace.edit("xmleditor").getSession().setValue(result["data"]);
            }
        },
        error: function (xhr) {
            console.log(xhr.responseText);
            alert("Error has occurred..");
        }
    });
}

function changeEngine() {
    var engine_ids = __engineids__;
    var engines = __engines__;
    var index = (engine_ids.indexOf($('#engine-id').val()) + 1) % engine_ids.length;
    var id = engine_ids[index];
    $('#engine-id').val(id);
    $('#engine-display').text(engines[id]);
    //$('#engine-dialog')
}

function displayData() {
    ace.edit("xmleditor").getSession().setValue($("#Xml").val());
    ace.edit("xpatheditor").getSession().setValue($("#XPath").val());
    ace.edit("outputdisplay").getSession().setValue($("#Result_Data").val());

    //clean up hidden data
    $("#Xml").val("");
    $("#XPath").val("");
    $("#Result_Result").val("");

    var engines = __engines__;
    var id = $('#Engine').val(id);
    $('#engine-id').val(id);
    $('#engine-display').text(engines[id]);
}

function saveDemo() {
    $.ajax({
        type: "POST",
        url: '/XPath/SaveDemo',
        contentType: 'application/json',
        data: getModel(),
        success: function (result) {
            if (result["error"] != "") {
                //$('#status').val(result["error"]);
                alert(result["error"]);
            } else {
                //alert("demo saved successfully! Id: " + result["data"]);
                window.location.href = result["data"];
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

    displayData();
});
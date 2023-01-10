$(document).ready(function () {
    // listen for change event on all <input type="file">
    $("input:file").change(function() {
        // set feedback with removing all of full path before \ - this line demonstrates JQuery's chaining method approach (.* is 0 or more of any character while \\ is a backslash)
        var feedback = $(this).val().replace(/.*\\/, "");
        // update our label with the feedback
        $("#lblFileToUpload").text(feedback);
    });
});
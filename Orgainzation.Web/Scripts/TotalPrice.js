$(document).ready(function() {
    $("#btn").click(function() {
        $.ajax({
            type: 'POST',
            async: true,
            cache: false,
            url: '@Url.Action("Contract","CountTotalPrice")',
            success: function(data) {
                $('#tbRes').text(data.val());
            }
        });
    });
});
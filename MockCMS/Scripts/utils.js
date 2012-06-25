(function()
{
    window.get = function (id) {
        $.getJSON('api/mocksiteapi/' + id);
    };
    $.postJSON = function (url, data, success, jqXHR, dataType) {
        $.ajax({
            type: 'POST',
            url: url,
            data: data,
            success: success,
            dataType: dataType,
            contentType: 'application/json'
        });
    };
})();
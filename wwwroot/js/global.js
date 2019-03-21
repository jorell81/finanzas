function capLock(e) {
    kc = e.keyCode ? e.keyCode : e.which;
    sk = e.shiftKey ? e.shiftKey : ((kc == 16) ? true : false);
    if (((kc >= 65 && kc <= 90) && !sk) || ((kc >= 97 && kc <= 122) && sk)) document.getElementById('mayus').style.visibility = 'visible';
    else document.getElementById('mayus').style.visibility = 'hidden';
}
var _Request = function(action, controller, json, ok, error, always, type) {

    if (action.length == 0 || controller.length == 0) {
        return false;
    }

    var baseObject = {
        method: 'post',
        url: location.origin + '/' + controller + '/' + action,
        beforeSend: function(xhr) { xhr.setRequestHeader('X-Key-Ajax', document.getElementById("ipHdKeyAjax").value); }
    };

    switch ((type == null || type == undefined || typeof(type) == "integer" ? 1 : type)) {
        case 2:
            baseObject.dataType = 'json';
            baseObject.contentType = "application/x-www-form-urlencoded; charset=UTF-8";
            baseObject.params = json;
            break;
        case 3:
            baseObject.dataType = 'html';
            baseObject.contentType = "application/json; charset=utf-8";
            baseObject.params = JSON.stringify(json);
            break;
        case 4:
            baseObject.dataType = 'json';
            baseObject.contentType = 'multipart/form-data';
            baseObject.params = json;
            baseObject.headers = {
                'VerificationToken': document.getElementById("forgeryToken").value
            };
            baseObject.processData = false;
            baseObject.contentType = false;
            break;
        default:
            baseObject.dataType = 'json';
            baseObject.contentType = "application/json; charset=utf-8";
            baseObject.params = JSON.stringify(json);
            baseObject.headers = {
                'VerificationToken': document.getElementById("forgeryToken").value
            };
            break;
    }
    axios(baseObject)
        .then(function(e) {
            return e.data;
        })
        .catch(function(e) {
            if ((error != undefined && error != null && typeof(error) === "function") && e != undefined) {
                error(e);
            }
        }).then(function(e) {
            if ((ok != undefined && ok != null && typeof(ok) === "function") && e != undefined) {
                ok(e);
            }
        });
};
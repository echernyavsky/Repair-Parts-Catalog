var CatalogApp = CatalogApp || {};

CatalogApp.namespace = function (nsString) {
    var parts = nsString.split('.'),
        parent = CatalogApp,
        i;
    if (parts[0] === "CatalogApp") {
        parts = parts.slice(1);
    }

    for (i = 0; i < parts.length; i += 1) {
        if (typeof parent[parts[i]] === "undefined") {
            parent[parts[i]] = {};
        }
        parent = parent[parts[i]];
    }
    return parent;
};

CatalogApp.namespace('CatalogApp.utilities.ajaxHelper');
CatalogApp.utilities.ajaxHelper = (function (jQuery) {
    var ajax = function (url, data, type) {
        return jQuery.ajax({
            url: url,
            type: type,
            data: data,
            dataType: 'json',
            contentType: "application/json; charset=utf-8"
        });
    };
    return {
        post: function (options) {
            return ajax(options.url, options.data, "POST");
        }
    };
})($);
/********** Bootstrap Modals ***************/
var createModalElement = function (templateName, viewModel, afterRenderElement) {
    var temporaryDiv = addHiddenDivToBody();
    var deferredElement = $.Deferred();
    ko.renderTemplate(
        templateName,
        viewModel,
        // We need to know when the template has been rendered,
        // so we can get the resulting DOM element.
        // The resolve function receives the element.
        {
            afterRender: function (nodes) {
                // Ignore any #text nodes before and after the modal element.
                var elements = nodes.filter(function (node) {
                    return node.nodeType === 1; // Element
                });
                deferredElement.resolve(elements[0]);
                afterRenderElement();
            }
        },
        // The temporary div will get replaced by the rendered template output.
        temporaryDiv,
        "replaceNode"
    );
    // Return the deferred DOM element so callers can wait until it's ready for use.
    return deferredElement;
};

var addHiddenDivToBody = function () {
    var div = document.createElement("div");
    div.style.display = "none";
    document.body.appendChild(div);
    return div;
};
var addModalHelperToViewModel = function (viewModel, deferredModalResult, context) {
    // Provide a way for the viewModel to close the modal and pass back a result.
    viewModel.modal = {
        close: function (result) {
            if (typeof result !== "undefined") {
                deferredModalResult.resolveWith(context, [result]);
            } else {
                // When result is undefined, we don't want any `done` callbacks of
                // the deferred being called. So reject instead of resolve.
                deferredModalResult.rejectWith(context, []);
            }
        }
    };
};

//pipe(function (modalElement) {
//    return $(modalElement);
//})

var showTwitterBootstrapModal = function ($ui) {
    // Display the modal UI using Twitter Bootstrap's modal plug-in.
    $ui.modal({
        // Clicking the backdrop, or pressing Escape, shouldn't automatically close the modal by default.
        // The view model should remain in control of when to close.
        backdrop: "static",
        keyboard: false
    });
};

var whenModalResultCompleteThenHideUI = function (deferredModalResult, $ui) {
    // When modal is closed (with or without a result)
    // Then always hide the UI.
    deferredModalResult.always(function () {
        $ui.modal("hide");
    });
};

var whenUIHiddenThenRemoveUI = function ($ui) {
    // Hiding the modal can result in an animation.
    // The `hidden` event is raised after the animation finishes,
    // so this is the right time to remove the UI element.
    $ui.on("hidden", function () {
        // Call ko.cleanNode before removal to prevent memory leaks.
        $ui.each(function (index, element) { ko.cleanNode(element); });
        $ui.remove();
    });
};
var showModal = function (options) {
    if (typeof options === "undefined") throw new Error("An options argument is required.");
    if (typeof options.viewModel !== "object") throw new Error("options.viewModel is required.");

    var viewModel = options.viewModel;
    var template = options.template || viewModel.template;
    var context = options.context;
    var afterRenderElement = options.afterRender || function () { };
    if (options.afterRenderFunction) {
        afterRenderElement = viewModel[options.afterRenderFunction];
    }

    if (!template) throw new Error("options.template or options.viewModel.template is required.");

    return createModalElement(template, viewModel, afterRenderElement)
        .pipe($) // jQueryify the DOM element
        .pipe(function ($ui) {
            var deferredModalResult = $.Deferred();
            addModalHelperToViewModel(viewModel, deferredModalResult, context);
            showTwitterBootstrapModal($ui);
            whenModalResultCompleteThenHideUI(deferredModalResult, $ui);
            whenUIHiddenThenRemoveUI($ui);
            return deferredModalResult;
        });
};

// Knockout binding handlers for select2
// e.g. https://github.com/ivaynberg/select2/wiki/Knockout.js-Integration

ko.bindingHandlers["select2"] = {
    after: ["options", "value", "selectedOptions"],
    init: function (element, valueAccessor) {
        $(element).select2(ko.unwrap(valueAccessor()));

        ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
            $(element).select2("destroy");
        });
    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        //var allBindings = allBindingsAccessor();
        //if (allBindings.options) { allBindings.options(); }
        //if (allBindings.value) { allBindings.value(); }
        //if (allBindings.selectedOptions) { allBindings.selectedOptions(); }
        $(element).trigger("change");
    }
};
(function () {
    var updateOptions = ko.bindingHandlers["options"]["update"];
    ko.bindingHandlers["options"]["update"] = function (element) {
        var ret = updateOptions.apply(null, arguments);
        var $el = $(element);
        if ($el.data("select2")) { $el.trigger("change"); }
        return ret;
    }
})();
(function () {
    var updateSelectedOptions = ko.bindingHandlers["selectedOptions"]["update"];
    ko.bindingHandlers["selectedOptions"]["update"] = function (element) {
        var ret = updateSelectedOptions.apply(null, arguments);
        var $el = $(element);
        if ($el.data("select2")) { $el.trigger("change"); }
        return ret;
    }
})();
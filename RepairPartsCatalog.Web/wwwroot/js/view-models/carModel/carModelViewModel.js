function CarModelViewModel(serverModel, brands, types) {
    var self = this;
    self.Id = ko.observable();
    self.Name = ko.observable();
    self.CarTypeId = ko.observable();
    self.CarBrandId = ko.observable();
    self.TypeName = ko.observable();
    self.BrandName = ko.observable();
    self.Brands = brands;
    self.Types = types;

    if (serverModel != null) {
        ko.mapping.fromJS(serverModel, {}, self);
    }


    self.AddNewBrand = function () {
        var ajax = CatalogApp.utilities.ajaxHelper,
            ajaxOptions = {
                url: window.urls.createModel,
                data: ko.mapping.toJSON(self)
            };

        ajax.post(ajaxOptions)
            .done(function (result) {
                self.modal.close(result);
            });
    };
}

CarModelViewModel.prototype.template = 'addModel-template';
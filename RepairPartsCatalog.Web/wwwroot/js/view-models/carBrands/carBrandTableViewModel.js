function CarBrandTableViewModel(serverModel) {
    var self = this;
    self.Brands = ko.observableArray();
    self.Types = ko.observableArray();
    self.Countries = ko.observableArray();

    var mappingOverride = {
        'Brands': {
            create: function (options) {
                return new window.CarBrandViewModel(options.data);
            }
        },
        'Types': {
            create: function (options) {
                return new window.CarTypeViewModel(options.data);
            }
        },
        'Countries': {
            create: function(options) {
                return new window.CountryViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.SelectType = function (type) {
        var ajax = CatalogApp.utilities.ajaxHelper,
            ajaxOptions = {
                url: window.urls.getTable,
                data: ko.mapping.toJSON(type)
            };

        ajax.post(ajaxOptions)
            .done(function (data) {
                ko.mapping.fromJS(data, mappingOverride, self);
            });
    };

    self.AddBrand = function () {
        showModal({
            viewModel: new CarBrandViewModel(null, self.Countries)
        }).done(function (newBrand) {
            var brand = new CarBrandViewModel(newBrand);
            self.Brands.push(brand);
        });
    };

    self.goToModels = function (brand) {
        var url = decodeURIComponent(window.urls.getModelsTable).replace('###', brand.Id());
        window.location.href = url;
    };
}
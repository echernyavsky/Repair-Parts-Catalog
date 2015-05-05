function CarModelTableViewModel(serverModel) {
    var self = this;
    self.Models = ko.observableArray();
    self.Brands = ko.observableArray();
    self.Types = ko.observableArray();

    var mappingOverride = {
        'Models': {
            create: function(options) {
                return new window.CarModelViewModel(options.data);
            }
        },
        'Brands': {
            create: function(options) {
                return new window.CarBrandViewModel(options.data);
            }
        },
        'Types': {
            create: function(options) {
                return new window.CarTypeViewModel(options.data);
            }
        }
    };

    ko.mapping.fromJS(serverModel, mappingOverride, self);

    self.AddModel = function() {
        showModal({
            viewModel: new CarModelViewModel(null, self.Brands, self.Types)
        }).done(function (newModel) {
            var model = new CarModelViewModel(newModel);
            self.Models.push(model);
        });
    };
}
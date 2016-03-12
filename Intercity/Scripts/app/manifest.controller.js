angular
    .module('intercityApp')
    .controller('ManifestController', ManifestController);

function ManifestController() {
    var vm = this;
    vm.name = "manifest";
}
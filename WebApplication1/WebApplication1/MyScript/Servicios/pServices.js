
app.service("ConfigService", function ($http) {

    var uri = "http://localhost:49372";

    this.get = function (id) {
        var req = $http.get(uri + '/api/Config/' + id);
        return req;
    };

    this.getAll = function () {
        var req = $http.get(uri + '/api/Config');
        return req;
    };

    this.post = function (configuracion) {
        var req =$http.post(uri+'/api/Config',configuracion);
        return req;
    };

    this.put = function (id, Config) {
        var request = $http({
            method: "put",
            url: uri + '/api/Config/' + id,
            data: Config
        });
        return request;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: uri + '/api/Config/' + id,
            data: id
        });
        return request;
    };
});


app.service("PromanagerService", function ($http) {

    var uri = "http://localhost:49372";

    this.get = function (id) {
        var req = $http.get(uri + '/api/ProjManager/' + id);
        return req;
    };

    this.getAll = function () {
        var req = $http.get(uri + '/api/ProjManager');
        return req;
    };

    this.post = function (promanager) {
        var req = $http.post(uri + '/api/ProjManager', promanager);
        return req;
    };

    this.put = function (id, promanager) {
        var request = $http({
            method: "put",
            url: uri + '/api/ProjManager/' + id,
            data: promanager
        });
        return request;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: uri + '/api/ProjManager/' + id,
            data: id
        });
        return request;
    };

});



app.service("ProyectoServices", function ($http) {

    var uri = "http://localhost:49372";

    this.getAllConfig = function () {
        var req = $http.get(uri + '/api/Config');
        return req;
    };

    this.getAllManager = function () {
        var req = $http.get(uri + '/api/ProjManager');
        return req;
    };


    this.get = function (id) {
        var req = $http.get(uri + '/api/Proyec/' + id);
        return req;
    };

    this.getAll = function () {
        var req = $http.get(uri + '/api/Proyec');
        return req;
    };

    this.post = function (proyecto) {
        var req = $http.post(uri + '/api/Proyec', proyecto);
        return req;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: uri + '/api/Proyec/' + id,
            data: id
        });
        return request;
    };
});



app.service("ProcompetitivoServices", function ($http) {

    var uri = "http://localhost:49372";


    this.getAllproyectos = function () {
        var req = $http.get(uri + '/api/Proyec');
        return req;
    };

    this.getAll = function () {
        var req = $http.get(uri + '/api/Procompetitivo');
        return req;
    };


    this.post = function (proceso) {
        var req = $http.post(uri + '/api/Procompetitivo', proceso);
        return req;
    };

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: uri + '/api/Proyec/' + id,
            data: id
        });
        return request;
    };
});
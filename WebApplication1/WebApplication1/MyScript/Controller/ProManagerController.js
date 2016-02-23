app.controller('ProManagerController', function ($scope, PromanagerService) {

    //VistaModelo
    $scope.Promager = {}; //Objeto Actual
    $scope.Promanagers = []; //Listado de Objetos
    $scope.editMode = false; // Modo de Edición

    initialize();
    loadRecords();
    function initialize() {
        $scope.Promager = {};
        $scope.Promager.ID_PROMANAGER = "";
        $scope.Promager.DOCUMENTO = "";
        $scope.Promager.NOMBRE = "";
        $scope.Promager.P_APELLIDO = "";
        $scope.Promager.S_APELLIDO = "";
        $scope.Promager.S_CARGO = "";
    }

    ///Function to load all Configuracion
    function loadRecords() {
        var promiseGet = PromanagerService.getAll(); //The Method Call from service
        promiseGet.then(function (pl) {
            $scope.Promanagers = pl.data;
        },
              function (errorPl) {
                  $log.error('Error al cargar los datos almacenados', errorPl);
        });
    }

    $scope.Nuevo = function () {
        initialize();
    }

    $scope.cancel = function () {
        console.log($scope.editMode);
        if (!$scope.editMode) {
            initialize();
        }
        $('#ModalEditar').modal('hide');
        $scope.editMode = false;
        initialize();
    };

    //Function to Submit the form
    $scope.Add = function () {
        var promanager = {};

        promanager.DOCUMENTO = $scope.Promager.DOCUMENTO;
        promanager.NOMBRE = $scope.Promager.NOMBRE;
        promanager.P_APELLIDO = $scope.Promager.P_APELLIDO;
        promanager.S_APELLIDO = $scope.Promager.S_APELLIDO;
        promanager.CARGO = $scope.Promager.CARGO;
        var result = PromanagerService.post(promanager);
        result.then(function () {
            setTimeout(function () {
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "progressBar": false,
                    "preventDuplicates": false,
                    "positionClass": "toast-bottom-full-width",
                    "onclick": null,
                    "showDuration": "400",
                    "hideDuration": "1000",
                    "timeOut": "7000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };
                toastr.success("Se realizado el registro de manera exitosa.", "SAC-Notificaciones");

            }, 1200);
            loadRecords();
            $('#myModal4').modal('hide');
        },
        function (errorpl) {
            console.log(errorpl)
        });

    };


    $scope.edit = function () {
        $scope.Promager = this.Promager;
        $scope.editMode = true;
        $('#ModalEditar').modal('show');
    };

    //Functin Para Actualizar
    $scope.update = function () {
        var promanager = {};

        promanager.ID_PROMANAGER = $scope.Promager.ID_PROMANAGER;
        promanager.DOCUMENTO = $scope.Promager.DOCUMENTO;
        promanager.NOMBRE = $scope.Promager.NOMBRE;
        promanager.P_APELLIDO = $scope.Promager.P_APELLIDO;
        promanager.S_APELLIDO = $scope.Promager.S_APELLIDO;
        promanager.CARGO = $scope.Promager.CARGO;

        var promisePost = PromanagerService.put(promanager.ID_PROMANAGER, promanager);
        promisePost.then(function (d) {
            setTimeout(function () {
                toastr.options = {
                    "closeButton": true,
                    "debug": false,
                    "progressBar": false,
                    "preventDuplicates": false,
                    "positionClass": "toast-bottom-full-width",
                    "onclick": null,
                    "showDuration": "400",
                    "hideDuration": "1000",
                    "timeOut": "7000",
                    "extendedTimeOut": "1000",
                    "showEasing": "swing",
                    "hideEasing": "linear",
                    "showMethod": "fadeIn",
                    "hideMethod": "fadeOut"
                };
                toastr.success("Datos actualizados de manera exitosa.", "SAC-Notificaciones");

            }, 1200);
            $('#ModalEditar').modal('hide');
            loadRecords();
        }, function (err) {
            alert("Some Error Occured " + JSON.stringify(err));
        });
    };

    $scope.remove = function () {
        $scope.Promager = this.Promager;
        var id = $scope.Promager.ID_PROMANAGER
        console.log($scope.Promager)
        swal({
            title: "Mensaje de confirmación",
            text: "¿Esta seguro que desea reomover el projer manager?" +
            "\n" + $scope.Promager.NOMBRE + $scope.Promager.P_APELLIDO,
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonText: "Si",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false
        },
            function (isConfirm) {
                if (isConfirm) {
                    var result = PromanagerService.delete($scope.Promager.ID_PROMANAGER);
                    result.then(function () {

                        loadRecords();
                        $('#myModal4').modal('hide');
                    },
                    function (errorpl) {
                        console.log(errorpl)
                    })
                    swal("Mensaje de Notificacion", "Se ha removido el resgitro de manera exitosa.", "success");
                } else {
                    swal("Mensaje de Notificacion", "El proceso de eliminacion no ha sido confirmado", "error");
                }
            });
    }

});
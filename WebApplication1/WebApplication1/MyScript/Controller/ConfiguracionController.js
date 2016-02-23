app.controller('ConfiguracionController', function ($scope, ConfigService, NgTableParams) {

    //VistaModelo
   
    $scope.Config = {}; //Objeto Actual
    $scope.Configs = []; //Listado de Objetos
    $scope.editMode = false; // Modo de Edición

    initialize();
    loadRecords();
    

    function initialize()
    {
        $scope.Config = {};
        $scope.Config.NOMBRE_CONFIG="";
        $scope.Config.TIPO_CONFIG = "";
    }

    ///Function to load all Configuracion
    function loadRecords() {
        var promiseGet = ConfigService.getAll(); //The Method Call from service
        promiseGet.then(function (pl) {
            var self = this;
            $scope.Configs = pl.data;
            },
              function (errorPl) {
                  $log.error('Error al cargar los datos almacenados', errorPl);
              });
    }

    //Function to Submit the form
    $scope.Add = function () {
        var configuracion = {};
        configuracion.NOMBRE_CONFIG = $scope.Config.NOMBRE_CONFIG;
        configuracion.TIPO_CONFIG = $scope.Config.TIPO_CONFIG;
        var result = ConfigService.post(configuracion);
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
                toastr.success("Se realizado el registro de manera exitosa.", "Sistema de Notificaciones");

            }, 1200);
            loadRecords();
            $('#myModal4').modal('hide');
        },
        function (errorpl) {
            console.log(errorpl)
        });
        
    };

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

    $scope.edit = function () {
        $scope.Config = this.Config;
        $scope.editMode = true;
        $('#ModalEditar').modal('show');
    };

    //Functin Para Actualizar
    $scope.update = function () {
        var configuracion = {};
        configuracion.CONFIG_ID = $scope.Config.CONFIG_ID;
        configuracion.NOMBRE_CONFIG = $scope.Config.NOMBRE_CONFIG;
        configuracion.TIPO_CONFIG = $scope.Config.TIPO_CONFIG;
        var promisePost = ConfigService.put(configuracion.CONFIG_ID, configuracion);
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
                toastr.success("Datos actualizados de manera exitosa.", "Sistema de Notificaciones");

            }, 1200);
            $('#ModalEditar').modal('hide');
            loadRecords();
        }, function (err) {
            alert("Some Error Occured " + JSON.stringify(err));
        });
    };


    $scope.remove = function () {
        $scope.Config = this.Config;
        var id = $scope.Config.PROYEC_ID

        swal({
            title: "Mensaje de confirmación",
            text: "¿Esta seguro que desea remover el registro?" +
            "\n" + $scope.Config.NOMBRE_CONFIG,
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
                  var result = ConfigService.delete($scope.Config.CONFIG_ID);
                  result.then(function () {
                      loadRecords();
                      $('#ModalEditar').modal('hide');
                  },
                  function (errorpl) {
                      console.log(errorpl)
                  });
                  swal("Mensaje de Notificacion", "El registro fue reomvido fue realizado de manera exitosa.", "success");
              } else {
                  swal("Mensaje de Notificacion", "El proceso de remocion no ha sido confirmado", "error");
              }
          });


      
    }
});
app.controller('AspiranteController', function ($scope, AspiranteServices) {
    $scope.Asp = {}; //Objeto Actual
    $scope.Aspirantes = []; //Listado de Objetos


    archivos = [];
    var file;
   
    inicialice();

    loadRecords();

    function loadRecords() {
        var promiseGet = AspiranteServices.getAll(); //The Method Call from service
        promiseGet.then(function (pl) {
            $scope.Aspirantes = pl.data;
            console.log(pl.data);
        },
        function (errorPl) {
            $log.error('Error al cargar los datos almacenados', errorPl);
        });
    }

    function inicialice() {
        $scope.Asp.NIT_CEDULA = "";
        $scope.Asp.NOM_RAZONSOCIAL = "";
        $scope.Asp.CORREO = "";
        $scope.Asp.DIRECCION = "";
        $scope.Asp.CIUDAD = "";
        $scope.Asp.DEPARTAMENTO = "";
        $scope.Asp.TELEFONO = "";
    }

    function relacion() {
        $scope.Asp.ID_ASPIRANTE = 0;
        var AspProceso = {};
        var DOCUMENTO_PRO = localStorage.getItem("PROCESO");

        AspProceso.ID_ASPIRANTE = $scope.Asp.ID_ASPIRANTE;
        AspProceso.ID_PROCESO = DOCUMENTO_PRO;

        console.log("CONFIRMAR ID_ASPIRANTE " + $scope.Asp.ID_ASPIRANTE);
        console.log("CONFIRMAR ID_COMPETITIVO " + DOCUMENTO_PRO);

        var result = AspiranteServices.relacion(AspProceso);
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
            }, 1100);
            loadRecords()
            localStorage.removeItem("ASPIRANTE")
            localStorage.removeItem("PROCESO")

            window.location = "#/Proyectos/ProCompetitivo"
        },
        function (errorpl) {
            console.log(errorpl)
        });
        /*PENDIENTE
        setTimeout(function () { $scope.Cargartodo() }, 1100)
        */
    }

    $scope.Add = function () {
        var aspirante = {};

        aspirante.NIT_CEDULA = $scope.Asp.NIT_CEDULA;
        aspirante.NOM_RAZONSOCIAL = $scope.Asp.NOM_RAZONSOCIAL;
        aspirante.CORREO = $scope.Asp.CORREO;
        aspirante.DIRECCION = $scope.Asp.DIRECCION;
        aspirante.CIUDAD = $scope.Asp.CIUDAD;
        aspirante.DEPARTAMENTO = $scope.Asp.DEPARTAMENTO;
        aspirante.TELEFONO = $scope.Asp.TELEFONO;
        
        var result = AspiranteServices.post(aspirante);
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

            }, 1100);
            loadRecords();
        },
        function (errorpl) {
            console.log(errorpl)
        });
        
        setTimeout(function () { relacion() }, 1100)
    };
        
    $scope.visualizar = function () {
        document.getElementById("lista").innerHTML = "";
        var files = document.getElementById('files').files;
        //var archivos = new FormData();
        //var item = "";
        for (i = 0; i < files.length; i++) {
            file = files[i];
            archivos.push({ 'id': i, 'file': file });
        }
        var item = "<table class='table table-striped'>";
        item += "<thead>";
        item += "<tr>";
        item += "<th></th>";
        item += "<th>Nombre de archivo</th>";
        item += "<th>Tamaño</th>";
        item += "<th>Acciones</th>";
        item += "</tr>";
        item += "</thead>";
        //cargando tabla
        for (i = 0; i < archivos.length; i++) {
            item += "<tr>";
            item += "<td>" + parseInt(i + 1) + ".</td>";
            item += "<td>" + archivos[i].file.name + "</td>";
            item += "<td style='font-size:12px'>" + (archivos[i].file.size / (1024 * 1024)).toFixed(2) + " MG</td>";
            item += '</td>';
            item += '<td>';
            item += '<a href="javasrcritp:;" title="Remover archivo" onclick="angular.element(this).scope().Removeritem(' + i + ');"><i class="fa fa-trash" style="font-size:20px;color:#ED5565;margin-left:20px"></i></a>';
            item += '</td>';
            item += "</tr>";
        }
        $("#lista").append(item);
        item += '</table>';


    }

    $scope.Cargartodo = function () {
        alert('aa')
        var files = $("#files").get(0).files;
        var data = new FormData();
        for (i = 0; i < files.length; i++) {
            data.append("file" + i, files[i]);
        }

        $.ajax({
            type: "POST",
            url: "api/listap",
            contentType: false,
            processData: false,
            data: data,
            success: function (result) {
                if (result) {
                    console.log('Archivos subidos correctamente');
                } else {
                    alert(result)
                }
            }
        });
    }

});
app.controller('ProCompetitivoController', function ($scope, ProcompetitivoServices) {

    $scope.visibilidadOff = false
    $scope.visibilidadOn = true
    archivos = [];
    $scope.Proceso = {};//Objeto actual
    $scope.Procesos = [];//Listado de Objetos
    var file;
    ///Datos proyectos
    $scope.Proyec = {};//Objeto actual
    $scope.Proyes = [];//Listado de Objetos
    loadRecord();

    $scope.CurrentDate = new Date();//Fecha actual
    inicialize();

    loadRecordProyectos();

    function inicialize() {
        $scope.Proyec = {};
        $scope.Proceso = {};
        $scope.Proyec.PROYECTO = "";
        $scope.Proyec.COMP_ADQUISICION = "";
        
        ///atos proceso competitivo
        $scope.Proceso.PROCESO ="";
        $scope.Proceso.PROCESO_INICIO;
        $scope.Proceso.TIEMPO_PROCESO ="";
        $scope.Proceso.FECHA_INICO = "";
        $scope.Proceso.FECHA_INIC_SERVICE = "";
        $scope.Proceso.TIEMPO_EJECUCION ="";
        $scope.Proceso.DETALLE_PS ="";
        $scope.Proceso.CANTIDAD ="";
        $scope.Proceso.UNIDAD ="";
        $scope.Proceso.LUGAR_EJECUCION ="";
        $scope.Proceso.VALOR_ESTIMADO="";
        $scope.Proceso.VALOR_TOTAL="";
        $scope.Proceso.PROYECTO_COMPETITIVO=""
    }

    function loadRecordProyectos() {
        var promiseGet = ProcompetitivoServices.getAllproyectos(); //The Method Call from service
        promiseGet.then(function (pl) {
            $scope.Proyes = pl.data;

        },
           function (errorPl) {
               console.log('Error al cargar los datos almacenados', errorPl);
           });
    }

    function loadRecord() {
        var promiseGet = ProcompetitivoServices.getAll(); //The Method Call from service
        promiseGet.then(function (pl) {
            $scope.Procesos = pl.data;
          
        },
           function (errorPl) {
               console.log('Error al cargar los datos almacenados', errorPl);
           });
    }

    $scope.LoadModal = function () {
        $('#modalproyectos').modal('show')

    }

    $scope.Mostrar = function () {
        $scope.visibilidadOff = true
        $scope.visibilidadOn = false

    }
    
    $scope.Cargar = function () {
        $scope.Proyec = this.Proyec;
        $scope.Proyec.PROYECTO = $scope.Proyec.PROYECTO;
        $scope.Proceso.LUGAR_EJECUCION = $scope.Proyec.CONTRATO;
        switch ($scope.Proyec.COMP_ADQUISICION) {
            
            case "A":
                $scope.Proyec.COMP_ADQUISICION = 180;
                calcularFI($scope.Proyec.COMP_ADQUISICION);
                break;
            case "B":
                $scope.Proyec.COMP_ADQUISICION = 120;
                calcularFI($scope.Proyec.COMP_ADQUISICION);
                break;
            case "C":
                $scope.Proyec.COMP_ADQUISICION = 90;
                calcularFI($scope.Proyec.COMP_ADQUISICION);
                break
            case "D":
                $scope.Proyec.COMP_ADQUISICION = 60;
                calcularFI($scope.Proyec.COMP_ADQUISICION);
                break;
        }
        localStorage.setItem('PROYECTO', $scope.Proyec.PROYEC_ID)
        $('#modalproyectos').modal('hide')
    }

    $scope.Ocultar = function () {
        $scope.visibilidadOff = false
        $scope.visibilidadOn = true

    }

    $scope.Add = function () {
        var Proceso= {}
        var PROYECTO = localStorage.getItem("PROYECTO");
        Proceso.PROCESO = $scope.Proceso.PROCESO;
        Proceso.PROCESO_INICIO = $scope.Proceso.PROCESO_INICIO;
        Proceso.TIEMPO_PROCESO = $scope.Proyec.COMP_ADQUISICION
        Proceso.FECHA_INICO = $scope.Proceso.FECHA_INICO;
        Proceso.FECHA_INIC_SERVICE = $scope.Proceso.FECHA_INIC_SERVICE;
        Proceso.TIEMPO_EJECUCION = $scope.Proceso.TIEMPO_EJECUCION;
        Proceso.DETALLE_PS = $scope.Proceso.DETALLE_PS;
        Proceso.CANTIDAD = $scope.Proceso.CANTIDAD;
        Proceso.UNIDAD = $scope.Proceso.UNIDAD;
        Proceso.LUGAR_EJECUCION = $scope.Proceso.LUGAR_EJECUCION;
        Proceso.VALOR_ESTIMADO = $scope.Proceso.VALOR_ESTIMADO;
        Proceso.VALOR_TOTAL = $scope.Proceso.VALOR_TOTAL;
        Proceso.PROYECTO_COMPETITIVO = PROYECTO;
        var result = ProcompetitivoServices.post(Proceso);
        result.then(function () {
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
            toastr.success("Se realizado el registro de manera exitosa.", "Notificaciones");
            inicialize();
            loadRecord();
            localStorage.removeItem("PROYECTO")
        },
        setTimeout(function () {$scope.Cargartodo()},1000),
        function (errorpl) {
            console.log(errorpl)
        });
        
        
    };

    var calcularFI = function (dias) {
        $scope.YearAct = $scope.CurrentDate.getFullYear();
        $scope.MesAct = ('0' + ($scope.CurrentDate.getMonth()+1)).slice(-2);
        $scope.DiaAct = ('0' + $scope.CurrentDate.getDate()).slice(-2);

        $scope.Proceso.FECHA_INICO = $scope.MesAct + "/" + $scope.DiaAct + "/" + $scope.YearAct;
        console.log($scope.Proceso.FECHA_INICO)

        var result = new Date($scope.Proceso.FECHA_INICO);
            result.setDate(result.getDate() + dias);

            /*console.log('0' + (result.getDate() + 1));
            console.log(('0' + (result.getMonth() + 1)));
            console.log(result.getFullYear());*/
            
            $scope.Proceso.FECHA_INIC_SERVICE = ('0' + (result.getDate())).slice(-2) + "/" + ('0' + (result.getMonth() + 1)).slice(-2) + "/" + result.getFullYear();
            //alert($scope.Proceso.FECHA_INIC_SERVICE);
    }


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
            item += "<td style='font-size:12px'>" + (archivos[i].file.size / (1024 * 1024)).toFixed(2) + " MG</td>" ;
            item += '</td>';
            item += '<td>';
            item += '<a href="javasrcritp:;" title="Remover archivo" onclick="angular.element(this).scope().Removeritem(' + i + ');"><i class="fa fa-trash" style="font-size:20px;color:#ED5565;margin-left:20px"></i></a>';
            item += '</td>';
           item +="</tr>";
        }
        $("#lista").append(item);
        item += '</table>';
       
        
    }

    $scope.Removeritem = function(i) {
        alert(i)
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
            url: "/api/Files",
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
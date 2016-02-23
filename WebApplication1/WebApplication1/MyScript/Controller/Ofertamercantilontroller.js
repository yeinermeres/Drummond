app.controller('Ofertamercantilontroller', function ($scope) {

    var Polizas = [];///Vector de Polizas creadas
    $scope.lispolizas = [];
    $scope.Poliza = {};
    initialize();
    $scope.CurrentDate = new Date();//Fecha actual

    function initialize() {
        $scope.Poliza = {};
        $scope.Poliza.NO_POLIZA = "";
        $scope.Poliza.FECHA_INI_POL = "";
        $scope.Poliza.COD_POLIZA = "";
        $scope.Poliza.FECHA_FINAL_POL="";
        $scope.Poliza.ASEGURADORA="";
        $scope.Poliza.VALOR_POLIZA="";
        $scope.Poliza.TIPO_POLIZA="";
        $scope.Poliza.VALOR_ASEGURADO = "";
    }

    $scope.CargarPoliza = function () {
        Polizas.push($scope.Poliza);
        document.getElementById("lispoliza").innerHTML = "";
        var item = "<table class='table table-striped'>";
        for (var i = 0; i < Polizas.length; i++)
        {
            item += "<tr>";
            item += "<td>" + i + "</td>";
            item += "<td>"+Polizas[i].COD_POLIZA+"</td>";
            item += "<td>"+Polizas[i].FECHA_INI_POL+"</td>";
            item += "<td>" + Polizas[i].FECHA_FINAL_POL + "</td>";
            item += "<td>" + Polizas[i].ASEGURADORA + "</td>";
            item += "<td>"+Polizas[i].VALOR_POLIZA+"</td>";
            item += "<td style='text-alin:center;'>" + Polizas[i].TIPO_POLIZA + "</td>";
            item += "<td>" + Polizas[i].VALOR_ASEGURADO + "</td>";
            item += "<td></td>";
            item += "<td style='text-align: center'><a href='javasrcritp:;' title='Eliminar Poliza' onclick='angular.element(this).scope().RemoverPoliza(" + i + ");'><i class='fa fa-trash' style='font-size:20px;color:#ED5565;'></i></a></td>";
            item += "</tr>";
        }
        item += "</table>";
        $("#lispoliza").append(item);
    }

    $scope.RemoverPoliza = function (i) {
        Polizas.splice(i, 1);
        document.getElementById("lispoliza").innerHTML = "";
        var item = "<table class='table table-striped'>";
        console.log(Polizas)
        for (var i = 0; i < Polizas.length; i++) {
            item += "<tr>";
            item += "<td>" + i + "</td>";
            item += "<td>" + Polizas[i].COD_POLIZA + "</td>";
            item += "<td>" + Polizas[i].FECHA_INI_POL + "</td>";
            item += "<td>" + Polizas[i].FECHA_FINAL_POL + "</td>";
            item += "<td>" + Polizas[i].ASEGURADORA + "</td>";
            item += "<td>" + Polizas[i].VALOR_POLIZA + "</td>";
            item += "<td style='text-alin:center;'>" + Polizas[i].TIPO_POLIZA + "</td>";
            item += "<td>" + Polizas[i].VALOR_ASEGURADO + "</td>";
            item += "<td></td>";
            item += "<td style='text-align: center'><a href='javasrcritp:;' title='Eliminar Poliza' onclick='angular.element(this).scope().RemoverPoliza(" + i + ");'><i class='fa fa-trash' style='font-size:20px;color:#ED5565;'></i></a></td>";
            item += "</tr>";
        }
        item += "</table>";
        $("#lispoliza").append(item);
    }

});
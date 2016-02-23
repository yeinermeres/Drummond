var app;
(function () {
    app = angular.module("myApp", ["ui.bootstrap", 'ngRoute', "ngTable"]);
    app.config(['$routeProvider', '$locationProvider', 
        function AppConfig($routeProvider, $locationProvider){
            $routeProvider
                .when('/DatosBasicos/Configuracion', {
                    templateUrl: 'DatosBasicos/Configuracion.html',
                    controller: 'ConfiguracionController'
                })
                .when('/DatosBasicos/ProjerManajer', {
                    templateUrl: 'DatosBasicos/ProjerManager.html',
                    controller: 'ProManagerController'
                })
                .when('/Proyectos/Proyectos', {
                    templateUrl: 'Proyectos/Proyectos/Proyectos.html',
                    controller: 'ProyectosController'
                })
                 .when('/Proyecto/Detalleproyec', {
                     templateUrl: 'Proyectos/Proyectos/Detalle_Proyec.html',
                     controller: 'ProyectosController'
                 })
                .when('/Proyectos/ProCompetitivo', {
                    templateUrl: 'Proyectos/ProcesoCompetitivo/ProCompetitivo.html',
                    controller: 'ProCompetitivoController'
                })
                .when('/DetalleCompetitivo', {
                    templateUrl: 'Proyectos/ProcesoCompetitivo/Detalle_Procompetitivo.html',
                })
                .when('/Proyectos/RegistroAspirante', {
                    templateUrl: 'Proyectos/ProcesoCompetitivo/RegistroAspirante.html',
                })
                .when('/OFM/REGOFM', {
                    templateUrl: 'OFM/GestionOFM.html',

                })
                .when('/OFM/OP', {
                    templateUrl: 'OFM/OP/Ordencompra.html',
                    controller: 'ordencompraController'
                })
                .when('/Notificaciones', {
                    templateUrl: 'Notificaciones/Notificaciones.html',
                })
                .when('/Historial', {
                    templateUrl: 'Historial/Historial.html',
                });

        }]);
})();
/*
 Arpateck Inc.
 Unidad: Registro.js
 Fecha: 18.Diciembre.2017
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el módulo de registro de usuario.
*/

'use strict';

//After loading the whole document, we will execute some functions.
$(window).load(function () {

    //load university list.
    GetUniversities();

});
//---------------------------------------------------------

$(function () {

    //Onchange for loading carreers.
    $(".dropdown-university").on("change", function () {
        var self = $(this);
        try {
            $.ajax({
                url: 'http://localhost:64954/administrator/resources/getcarreersbyuniversity/' + self.val(),
                type: 'post',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $(".dropdown-carreer").html('');
                    $.each(data, function (i, item) {
                        $(".dropdown-carreer").append('<option value="'+item.id_carrera+'">'+item.NombreCarrera+'</option>');
                    });
                },
                error: function (xhr, e, k) {
                    console.log(xhr.responseText);
                }
            });
        } catch (e) {
            console.log(e);
        }
    });
    //---------------------------------------------------------

    //Onchange for loading carreers.
    $(".dropdown-carreer").on("change", function () {

        var self = $(this);

        try {
            $.ajax({
                url: 'http://localhost:64954/administrator/resources/getgroupsbycarreer/' + self.val(),
                type: 'post',
                cache: false,
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (data) {
                    $(".dropdown-carreer").html('');
                    $.each(data, function (i, item) {
                        $(".dropdown-group").append('<option value="' + item.id_grupo + '">' + item.grado + ' - '+ item.grupo +'</option>');
                    });
                },
                error: function (xhr, e, k) {
                    console.log(xhr.responseText);
                }
            });
        } catch (e) {
            console.log(e);
        }
    });
    //---------------------------------------------------------


});

function GetUniversities() {
    try {
        $.ajax({
            url: 'http://localhost:64954/administrator/resources/getuniversities',
            type: 'post',
            cache: false,
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function (data) {
                $.each(data, function (i, item) {
                    $(".dropdown-university").append('<option value="'+item.id_universidad+'">'+item.NombreUniversidad+'</option>');
                });
            },
            error: function (xhr, error, e) {
                console.log("An error has ocurred.. " + xhr.responseText);
            }
        });
    } catch (e) {
        console.log(e);
    }
}
//---------------------------------------------------------
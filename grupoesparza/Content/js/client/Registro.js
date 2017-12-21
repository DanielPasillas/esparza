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
                    $(".dropdown-carreer").append('<option>-- Selecciona tu carrera --</option>');
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
                    $(".dropdown-group").html('');
                    $(".dropdown-group").html('<option>-- Selecciona tu grupo --</option>');
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

    setInterval(function () {
        RandomGallery()
    }, 9090);
});

function RandomGallery()
{
    var items = Array('emporio.jpg', 'grecia.jpg', 'zafari.jpg', 'miriam.jpg','zenca.jpg');

    var selected = items[Math.floor(Math.random() * items.length)];
    $('.img-gallery-container').fadeOut(500, function () {
        $('.img-gallery-container').attr('src', '../Content/img/varias/' + selected);
    }).fadeIn(500);
}


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
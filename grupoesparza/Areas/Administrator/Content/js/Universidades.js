/*
 Arpateck Inc.
 Unidad: Universidades.js
 Autor: daniel.pasillas
 Descripción: Aquí se definen los métodos y funciones para el módulo de universidades.
*/

$(function () {

    'use strict';

    //Event Add, show form university.
    $(".add-university").one("click", function () {

        try {

            $.ajax({
                url:  'nueva',
                type: 'post',
                cache: false,
                data: {},
                dataType: 'html',
                success: function (content) {
                    $("#form-container").html(content);
                },
                error: function (error) {
                    console.log(error.status);
                }
            });

        } catch (e) {
            console.log("An exception has ocurred" + e);
        }

    });
    //---------------------------------------------

    $(".table-university").on("click", ".delete-university", function () {
        if (confirm("¿Realmente desea eliminar la Universidad?"))
        {
            try {

                var self = $(this);

                $.ajax({
                    url: 'delete?id=' + self.attr('data-id-uni'),
                    type: 'post',
                    dataType: 'json',
                    success: function (response) {
                        var request = JSON.parse(response);
                    },
                    error: function (error) {
                        console.log("An error has ocurred " + error);
                    }
                });

            } catch (e) {
                console.log(e);
            }
        }
        else {
            return;
        }
    });
   //---------------------------------------------

    $(".table-university").on("click", ".edit-university", function () {
        try {

            var self = $(this);

            $.ajax({
                url: 'edit?id=' + self.attr('data-id-uni'),
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    var request = JSON.parse(response);
                },
                error: function (error) {
                    console.log("An error has ocurred " + error);
                }
            });

        } catch (e) {
            console.log(e);
        }
    });
    //---------------------------------------------
});
/// <reference path="../../typings/jquery/jquery.d.ts" />

module PancakeProwler.Shared {
    export class Menu {
        
        constructor (public top: Window) { }

        Init() {
            var location = top.location.toString();
            if (location.indexOf("Upcoming") > 0)
                $(".menu-upcoming").addClass("active");
            else if (location.indexOf("Recipe") > 0)
                $(".menu-recipes").addClass("active");
            else if (location.indexOf("Meal") > 0)
                $(".menu-meal").addClass("active");
            else if (location.indexOf("About") > 0)
                $(".menu-about").addClass("active");
            else
                $(".menu-today").addClass("active");
        }
    }
}

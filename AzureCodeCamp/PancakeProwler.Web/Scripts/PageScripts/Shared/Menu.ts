module PancakeProwler.Shared {
    export class Menu {
        
        constructor (public top: Window) { }

        Init() {
            alert(top.location.toString());

        }
    }
}

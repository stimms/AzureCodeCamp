var PancakeProwler;
(function (PancakeProwler) {
    (function (Shared) {
        var Menu = (function () {
            function Menu(top) {
                this.top = top;
            }
            Menu.prototype.Init = function () {
                alert(top.location.toString());
            };
            return Menu;
        })();
        Shared.Menu = Menu;        
    })(PancakeProwler.Shared || (PancakeProwler.Shared = {}));
    var Shared = PancakeProwler.Shared;
})(PancakeProwler || (PancakeProwler = {}));

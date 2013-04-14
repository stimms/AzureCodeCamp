var PancakeProwler;
(function (PancakeProwler) {
    (function (Recipe) {
        (function (Index) {
            var BookGenerator = (function () {
                function BookGenerator(activationSelector, email, name, successAlert) {
                    this.email = email;
                    this.name = name;
                    this.successAlert = successAlert;
                    $(activationSelector).on("click", $.proxy(this.submit, this));
                }
                BookGenerator.prototype.submit = function () {
                    var _this = this;
                    $.get("/Recipe/CreateBook", {
                        eMail: this.email.val(),
                        name: this.name.val()
                    }, function () {
                        _this.successAlert.removeClass("hidden");
                    });
                };
                return BookGenerator;
            })();
            Index.BookGenerator = BookGenerator;            
        })(Recipe.Index || (Recipe.Index = {}));
        var Index = Recipe.Index;
    })(PancakeProwler.Recipe || (PancakeProwler.Recipe = {}));
    var Recipe = PancakeProwler.Recipe;
})(PancakeProwler || (PancakeProwler = {}));

/// <reference path="../../typings/jquery/jquery.d.ts" />

module PancakeProwler.Recipe.Index {
    export class BookGenerator {
       
        constructor(activationSelector: HTMLElement, public email, public name, public successAlert) {
            $(activationSelector).on("click", $.proxy(this.submit, this));
        }
        
        submit() {
            $.get("/Recipe/CreateBook", { eMail: this.email.val(), name: this.name.val() }, () => { this.successAlert.removeClass("hidden") });
        }
    }
}
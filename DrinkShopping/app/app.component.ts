import { Component } from "@angular/core"

@Component({
    selector: "drink-app",
    template: `
                <div>223423423444444
                    <nav class='navbar navbar-inverse'>
                        <div class='container-fluid'>
                            <ul class='nav navbar-nav'>
                                <li><a [routerLink]="['home']">Home</a></li>
                                <li><a [routerLink]="['drink']">Drink Shopping</a></li>
                            </ul>
                        </div>
                    </nav>
                    <div class='container'>
                        <router-outlet></router-outlet>
                    </div>
                 </div>
                `
})

export class AppComponent {

}
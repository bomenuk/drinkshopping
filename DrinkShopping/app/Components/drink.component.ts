import { Component, OnInit, ViewChild } from '@angular/core';
import { DrinkService } from '../Service/drink.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { IDrink } from '../Model/drink';
import { RepoOperation } from '../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({
    templateUrl: 'app/Components/drink.component.html'
})

export class DrinkComponent implements OnInit {

    @ViewChild('modal') modal: ModalComponent;
    drinks: IDrink[];
    drink: IDrink;
    msg: string;
    indLoading: boolean = false;
    drinkForm: FormGroup;
    dbops: RepoOperation;
    modalTitle: string;
    modalBtnTitle: string;

    constructor(private fb: FormBuilder, private _drinkService: DrinkService) { }

    ngOnInit(): void {
        this.drinkForm = this.fb.group({
            Id: [''],
            FirstName: ['', Validators.required],
            LastName: [''],
            Gender: ['', Validators.required]
        });
        this.LoadDrinks();
    }

    LoadDrinks(): void {
        this.indLoading = true;
        this._drinkService.get(Global.BASE_DRINK_ENDPOINT)
            .subscribe(drinks => { this.drinks = drinks; this.indLoading = false; },
            error => this.msg = <any>error);
    }

    addDrink() {
        this.dbops = RepoOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Drink";
        this.modalBtnTitle = "Add";
        this.drinkForm.reset();
        this.modal.open();
    }

    editDrink(id: number) {
        this.dbops = RepoOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Drink";
        this.modalBtnTitle = "Update";
        this.drink = this.drinks.filter(x => x.Id == id)[0];
        this.drinkForm.setValue(this.drinks);
        this.modal.open();
    }

    deleteDrink(id: number) {
        this.dbops = RepoOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.drink = this.drinks.filter(x => x.Id == id)[0];
        this.drinkForm.setValue(this.drinks);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";
   
        switch (this.dbops) {
            case RepoOperation.create:
                this._drinkService.post(Global.BASE_DRINK_ENDPOINT, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully added.";
                            this.LoadDrinks();
                        }
                        else
                        {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }
                        
                        this.modal.dismiss();
                    },
                    error => {
                      this.msg = error;
                    }
                );
                break;
            case RepoOperation.update:
                this._drinkService.put(Global.BASE_DRINK_ENDPOINT, formData._value.Id, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully updated.";
                            this.LoadDrinks();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case RepoOperation.delete:
                this._drinkService.delete(Global.BASE_DRINK_ENDPOINT, formData._value.Id).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Data successfully deleted.";
                            this.LoadDrinks();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;

        }
    }

    SetControlsState(isEnable: boolean)
    {
        isEnable ? this.drinkForm.enable() : this.drinkForm.disable();
    }
}
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  @Output() cancelRegister = new EventEmitter();

  constructor(private _authService: AuthService) { }

  ngOnInit() {
  }

  register() {
    this._authService.register(this.model).subscribe(() => {
      console.log('registration successful');
    }, error => {
      console.error(error);
    })
  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('cancelled');
  }

}

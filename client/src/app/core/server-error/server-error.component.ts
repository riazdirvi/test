import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-server-error',
  templateUrl: './server-error.component.html',
  styleUrls: ['./server-error.component.scss']
})
export class ServerErrorComponent implements OnInit {
  error: any;

  constructor(private router: Router) {
    const navigation = this.router.getCurrentNavigation();
    this.error = navigation && navigation.extras && navigation.extras.state &&
    navigation.extras.state.error;

    //we can now use the optional chaining here which works the same way e.g
    // this.error = navigation?.extras?.state?.error;
   }

  ngOnInit(): void {
  }

}

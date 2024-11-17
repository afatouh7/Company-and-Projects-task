import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CompanyService } from '../services/CompanyService ';

@Component({
  selector: 'app-company-create',
  templateUrl: './company-create.component.html',
  styleUrls: ['./company-create.component.css']
})
export class CompanyCreateComponent {
  companyForm: FormGroup;
  constructor(
    private companyService: CompanyService,
    private router: Router,
    private fb: FormBuilder
  ) {
    // Initialize the form group with validation
    this.companyForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      address: ['', [Validators.required, Validators.minLength(5)]],
      isDeleted: [false]
    });
  }
  get form() {
    return this.companyForm.controls;
  }

  onSubmit() {
    if (this.companyForm.invalid) {
      return;
    }

    const company = this.companyForm.value;
    this.companyService.addCompany(company).subscribe({
      next: (response) => {
        console.log('Company created successfully:', response);
        this.router.navigate(['/']); // Redirect to home page after success (or to any other route)
      },
      error: (err) => {
        console.error('Error creating company:', err);
      }
    });
  }
}

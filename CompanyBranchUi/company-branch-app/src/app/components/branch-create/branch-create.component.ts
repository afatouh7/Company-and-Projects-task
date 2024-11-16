import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Branch } from 'src/app/models/branch';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-branch-create',
  templateUrl: './branch-create.component.html',
  styleUrls: ['./branch-create.component.css']
})
export class BranchCreateComponent {
  branch: Branch = { id: 0, name: '', company: '', isDeleted: false };

  constructor(private branchService: BranchService, private router: Router) {}

  createBranch(): void {
    this.branchService.createBranch(this.branch).subscribe({
      next: () => this.router.navigate(['/']),
      error: (err) => console.error('Error creating branch:', err),
    });
  }
}

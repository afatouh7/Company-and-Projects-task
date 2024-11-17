import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Branch } from 'src/app/models/branch';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-branch-update',
  templateUrl: './branch-update.component.html',
  styleUrls: ['./branch-update.component.css']
})
export class BranchUpdateComponent {
  branch: Branch | null = null;
  isCompanyDisabled = true;
  constructor(
    private route: ActivatedRoute,
    private branchService: BranchService,
    private router: Router
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.branchService.getBranch(id).subscribe({
        next: (branch) => (this.branch = branch), 
        error: (err) => console.error('Error fetching branch:', err),
      }); 
      
    }
  }

  updateBranch(): void {
    if (this.branch && this.branch.id !== undefined) {
      this.branchService.updateBranch(this.branch.id, this.branch).subscribe({
        next: (response) => {
          console.log('Branch updated successfully:', response);
          this.router.navigate(['/']);
        },
        error: (err) => console.error('Error updating branch:', err),
      });
    } else {
      console.error('Branch ID is undefined');
    }
  }
}
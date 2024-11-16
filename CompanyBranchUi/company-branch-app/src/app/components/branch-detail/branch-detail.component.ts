import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Branch } from 'src/app/models/branch';
import { BranchService } from 'src/app/services/branch.service';

@Component({
  selector: 'app-branch-detail',
  templateUrl: './branch-detail.component.html',
  styleUrls: ['./branch-detail.component.css']
})
export class BranchDetailComponent {
  branch: Branch | null = null;

  constructor(
    private route: ActivatedRoute,
    private branchService: BranchService
  ) {}

  ngOnInit(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    if (id) {
      this.branchService.getBranch(id).subscribe({
        next: (branch) => (this.branch = branch),
        error: (err) => console.error(err),
      });
    }
  }
}
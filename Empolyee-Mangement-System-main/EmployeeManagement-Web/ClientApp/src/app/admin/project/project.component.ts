import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from '../admin.service';
import { ProjectViewModel } from '../Model/project.model';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css'],
})
export class ProjectComponent implements OnInit {
  projectList!: ProjectViewModel[];

  constructor(private adminService: AdminService, private router: Router) {}

  ngOnInit(): void {
    this.adminService.getAllProject().subscribe((data) => {
      this.projectList = data;
    });
  }
  addProject() {
    this.router.navigateByUrl('admin/addProject');
  }

  viewProject(id: number) {
    // this.router.navigate(['admin/ProjectView'])
  }
  editProject(id: number) {
    // this.router.navigate(['admin/EditProject',id])
  }
  deleteProject(id: number) {}
}

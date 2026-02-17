import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Games } from "./games/games";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-root',
  imports: [Games, CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('RestApiLearning');
}

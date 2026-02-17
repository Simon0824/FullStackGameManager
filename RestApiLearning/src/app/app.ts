import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Games } from "./games/games";
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
  imports: [Games, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('RestApiLearning');
}

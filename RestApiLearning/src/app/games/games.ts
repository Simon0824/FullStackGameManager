import { NgFor } from '@angular/common';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { GameService } from '../services/game';
import { Game } from '../models/game';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-games',
  imports: [ CommonModule, NgFor ],
  templateUrl: './games.html',
  styleUrl: './games.css',
})
export class Games implements OnInit {

  games: Game[] = [];
  constructor(private gameService: GameService) {}
  ngOnInit(): void {
    this.loadGames();
  }

  
  loadGames() {
    console.log('Loading games...');
    this.gameService.getGames().subscribe(data => {
      this.games = data;
    });
  }

  delete(id: number) {
    console.log(`Deleting game with id: ${id}`);
    this.gameService.deleteGame(id).subscribe(() => {
      this.loadGames();
    });
  }
}

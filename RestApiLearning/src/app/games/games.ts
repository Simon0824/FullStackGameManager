import { NgFor } from '@angular/common';
import { NgForm } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { GameService } from '../services/game';
import { Game, GameDto } from '../models/game';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-games',
  imports: [ CommonModule, NgFor, FormsModule],
  templateUrl: './games.html',
  styleUrl: './games.css',
})
export class Games implements OnInit {

  newGame: GameDto = {
  title: '',
  genre: '',
  releaseDate: ''
  }
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

  addGame(){
    console.log('Adding game:', this.newGame);
    this.gameService.addGame(this.newGame).subscribe(() => {
      this.loadGames();
      this.newGame = {
        title: '',
        genre: '',
        releaseDate: ''
      };
   });
  }
}


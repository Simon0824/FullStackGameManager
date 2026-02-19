import { NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { GameService } from '../services/game';
import { Game, GameDto, GameUpdateDto } from '../models/game';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-games',
  imports: [ CommonModule, NgFor, FormsModule],
  templateUrl: './games.html',
  styleUrl: './games.css',
})
export class Games implements OnInit {

  isUpdateMode: boolean = false;
  updateGame: GameUpdateDto = {
  title: '',
  genre: '',
  price: 0,
  id: 0,
  releaseDate: ''
  };

  newGame: GameDto = {
  title: '',
  genre: '',
  price: 0,
  releaseDate: ''
  }
  
  games: Game[] = [];

  constructor(private gameService: GameService) {}
  ngOnInit(): void {
    this.loadGames();
  }

  isUpdateModeEnabled(id: number){
    this.isUpdateMode = true;
    this.updateGame.id = id;
    this.updateGame.title = this.games.find(g => g.id === id)?.title || '';
    this.updateGame.genre = this.games.find(g => g.id === id)?.genre || '';
    this.updateGame.price = this.games.find(g => g.id === id)?.price || 0;
    this.updateGame.releaseDate = this.games.find(g => g.id === id)?.releaseDate || '';
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

  add(){
    console.log('Adding game:', this.newGame);
    this.gameService.addGame(this.newGame).subscribe(() => {
      this.loadGames();
      this.newGame = {
        title: '',
        genre: '',
        price: 0,
        releaseDate: ''
      };
   });
  }

  update(id: number, game: GameUpdateDto) {
    console.log(`Updating game with id: ${id}`, game);
    this.gameService.updateGame(id, game).subscribe(() => {
      this.loadGames();
      this.updateGame = {
        title: '',
        genre: '',
        price: 0,
        id: id,
        releaseDate: ''
      };
      this.isUpdateMode = false;
    });
  }
}


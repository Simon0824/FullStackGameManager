export interface Game {
  id: number;
  title: string;
  genre: string;
  price: number;
  releaseDate: string;
}

export interface GameDto {
  title: string;
  genre: string;
  price: number;
  releaseDate: string;
}

export interface GameUpdateDto {
  title: string;
  genre: string;
  price: number;
  id: number;
  releaseDate: string;
}
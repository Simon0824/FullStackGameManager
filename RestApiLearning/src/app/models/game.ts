export interface Game {
  id: number;
  title: string;
  genre: string;
  releaseDate: string;
}

export interface GameDto {
  title: string;
  genre: string;
  releaseDate: string;
}
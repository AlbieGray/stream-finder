export interface SearchResult {
  id: number
  name: string
  year: number | null
  poster: string | null
  type: string
  imdb_id: string | null
  tmdb_id: number | null
}

export interface TitleDetail {
  id: number
  title: string
  year: number | null
  runtime_minutes: number | null
  plot_overview: string | null
  poster: string | null
  backdrop: string | null
  imdb_id: string | null
  tmdb_id: number | null
  genres: string[] | null
  user_rating: number | null
  critic_score: number | null
  type: string
  relevancy_score: number | null
}

export interface TitleSource {
  source_id: number
  name: string
  type: 'sub' | 'free' | 'rent' | 'buy' | 'tve'
  region: string
  web_url: string | null
  android_url: string | null
  ios_url: string | null
  format: string | null
  price: number | null
  currency: string | null
}

export interface Source {
  id: number
  name: string
  type: string
  regions: string[]
  logo_url: string
}

export interface Region {
  id: number
  name: string
  country_code: string
}

import type { SearchResult, TitleDetail, TitleSource, Source, Region } from '../types'

export async function searchTitles(query: string): Promise<SearchResult[]> {
  const res = await fetch(`/api/search?q=${encodeURIComponent(query)}`)
  if (!res.ok) throw new Error('Search failed')
  const data = await res.json()
  return data.title_results ?? []
}

export async function getTitleDetail(id: number): Promise<TitleDetail> {
  const res = await fetch(`/api/titles/${id}`)
  if (!res.ok) throw new Error('Failed to fetch title details')
  return res.json()
}

export async function getTitleSources(
  id: number,
  region?: string
): Promise<TitleSource[]> {
  const params = region ? `?region=${region}` : ''
  const res = await fetch(`/api/titles/${id}/sources${params}`)
  if (!res.ok) throw new Error('Failed to fetch sources')
  return res.json()
}

export async function getSources(): Promise<Source[]> {
  const res = await fetch('/api/sources')
  if (!res.ok) throw new Error('Failed to fetch sources')
  return res.json()
}

export async function getRegions(): Promise<Region[]> {
  const res = await fetch('/api/regions')
  if (!res.ok) throw new Error('Failed to fetch regions')
  return res.json()
}

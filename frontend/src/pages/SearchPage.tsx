import { useState, useCallback } from 'react'
import { useNavigate } from 'react-router-dom'
import { searchTitles } from '../services/api'
import type { SearchResult } from '../types'

export default function SearchPage() {
  const [query, setQuery] = useState('')
  const [results, setResults] = useState<SearchResult[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState('')
  const navigate = useNavigate()

  const handleSearch = useCallback(async (q: string) => {
    setQuery(q)
    if (!q.trim()) {
      setResults([])
      return
    }
    setLoading(true)
    setError('')
    try {
      const data = await searchTitles(q)
      setResults(data)
    } catch {
      setError('Failed to search. Please try again.')
    } finally {
      setLoading(false)
    }
  }, [])

  return (
    <main>
      <div className="test-banner">CI/CD pipeline test — deployed via GitHub Actions</div>
      <h1>Stream Finder</h1>
      <p className="subtitle">Find where movies and shows are streaming</p>
      <input
        type="text"
        placeholder="Search for a title..."
        value={query}
        onChange={(e) => handleSearch(e.target.value)}
        autoFocus
      />
      {loading && <p className="status">Searching...</p>}
      {error && <p className="status error">{error}</p>}
      <div className="results">
        {results.map((r) => (
          <button
            key={r.id}
            className="card"
            onClick={() => navigate(`/title/${r.id}`)}
          >
            {r.poster ? (
              <img src={r.poster} alt={`${r.name} poster`} />
            ) : (
              <div className="no-poster">No poster</div>
            )}
            <div className="info">
              <strong>{r.name}</strong>
              <span>{r.year}</span>
            </div>
          </button>
        ))}
      </div>
    </main>
  )
}

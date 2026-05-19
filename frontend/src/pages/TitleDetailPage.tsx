import { useEffect, useState } from 'react'
import { useParams, useNavigate } from 'react-router-dom'
import { getTitleDetail, getTitleSources } from '../services/api'
import type { TitleDetail, TitleSource } from '../types'

export default function TitleDetailPage() {
  const { id } = useParams<{ id: string }>()
  const navigate = useNavigate()
  const [detail, setDetail] = useState<TitleDetail | null>(null)
  const [sources, setSources] = useState<TitleSource[]>([])
  const [loading, setLoading] = useState(true)
  const [error, setError] = useState('')

  useEffect(() => {
    if (!id) return
    const numericId = Number(id)
    setLoading(true)
    setError('')

    Promise.all([
      getTitleDetail(numericId),
      getTitleSources(numericId),
    ])
      .then(([detailData, sourcesData]) => {
        setDetail(detailData)
        setSources(sourcesData)
      })
      .catch(() => setError('Failed to load title details.'))
      .finally(() => setLoading(false))
  }, [id])

  if (loading) return <main><p className="status">Loading...</p></main>
  if (error) return <main><p className="status error">{error}</p></main>
  if (!detail) return <main><p className="status">Title not found.</p></main>

  const sourceTypes = [
    { key: 'sub', label: 'Subscription' },
    { key: 'free', label: 'Free' },
    { key: 'rent', label: 'Rental' },
    { key: 'buy', label: 'Purchase' },
  ] as const

  return (
    <main>
      <button className="back" onClick={() => navigate('/')}>← Back</button>
      <div className="detail-header">
        {detail.poster != null && <img src={detail.poster} alt={`${detail.title} poster`} />}
        <div>
          <h1>{detail.title} ({detail.year})</h1>
          <p className="genres">{detail.genres?.join(', ')}</p>
          {detail.runtime_minutes != null && detail.runtime_minutes > 0 && (
            <p>{detail.runtime_minutes} min</p>
          )}
          {detail.user_rating != null && detail.user_rating > 0 && (
            <p>User rating: {detail.user_rating}/10</p>
          )}
          {detail.critic_score != null && detail.critic_score > 0 && (
            <p>Critic score: {detail.critic_score}%</p>
          )}
          {detail.plot_overview && <p className="plot">{detail.plot_overview}</p>}
        </div>
      </div>

      <h2>Where to Watch</h2>
      {sourceTypes.map(({ key, label }) => {
        const filtered = sources.filter((s) => s.type === key)
        if (filtered.length === 0) return null
        return (
          <div key={key}>
            <h3>{label}</h3>
            <div className="source-grid">
              {filtered.map((s) => (
                <a
                  key={s.source_id}
                  href={s.web_url ?? ''}
                  target="_blank"
                  rel="noopener noreferrer"
                  className="source-chip"
                >
                  {s.name}
                  {s.price && <span className="price">{s.price} {s.currency}</span>}
                </a>
              ))}
            </div>
          </div>
        )
      })}
    </main>
  )
}

import { BrowserRouter, Routes, Route } from 'react-router-dom'
import SearchPage from './pages/SearchPage'
import TitleDetailPage from './pages/TitleDetailPage'

export default function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<SearchPage />} />
        <Route path="/title/:id" element={<TitleDetailPage />} />
      </Routes>
    </BrowserRouter>
  )
}

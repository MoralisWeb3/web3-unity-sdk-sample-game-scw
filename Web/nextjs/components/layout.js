// components/layout.js

import TopNav from './topnav'
import BottomNav from './bottomnav'

export default function Layout({ children }) {
  return (
    <>
      <TopNav />
      <main>{children}</main>
      <BottomNav />
    </>
  )
}

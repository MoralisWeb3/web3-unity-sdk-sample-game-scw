import Image from 'next/image'
import Link from 'next/link'

function HomePage() {
    return  <div>
                <ol>
                    <li>Visit the<Link href="/signin"><a>Sign In</a></Link>!</li> 
                    <li>See you <Link href="/user"><a>User</a></Link>!</li> 
                    <li>See all <Link href="/native"><a>Nft Property</a></Link> Info</li> 
                </ol>
                <p> /native and /user</p>   
                <Image  
                    src="/Screenshot_07.png"
                    width={200}
                    height={100}
                     /> 
            </div>
}   

export default HomePage;


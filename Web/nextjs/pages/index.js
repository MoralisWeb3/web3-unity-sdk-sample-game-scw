import Image from 'next/image'

function HomePage() {
    return  <div>
                <h1>Sim City Web3 - Web Companion</h1>
                <ol>
                    <li>Visit the <a href="./signin">Sign In</a></li>
                    <li>See your <a href="./user">User</a> data</li>
                    <li>See all <a href="./native">Native</a> Nft property data</li>
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

